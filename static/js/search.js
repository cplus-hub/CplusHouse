document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('search-input');
    const searchResults = document.getElementById('search-results');
    const defaultList = document.getElementById('default-list');
    
    if (!searchInput || !searchResults) return;

    let posts = [];
    // 取得索引檔路徑，若無則預設為 /index.json
    const searchIndexUrl = searchInput.getAttribute('data-search-index') || '/index.json';

    const escapeHtml = (value) => String(value ?? '')
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#039;');

    const escapeRegExp = (value) => String(value).replace(/[.*+?^${}()|[\]\\]/g, '\\$&');

    const highlightText = (value, query) => {
        const escapedText = escapeHtml(value);
        const escapedQuery = escapeHtml(query);
        if (!escapedQuery) return escapedText;

        const pattern = new RegExp(escapeRegExp(escapedQuery), 'gi');
        return escapedText.replace(pattern, '<mark class="search-highlight">$&</mark>');
    };

    const createSnippet = (post, query) => {
        const content = String(post.content || '');
        const lowerContent = content.toLowerCase();
        const lowerQuery = query.toLowerCase();
        const matchIndex = lowerContent.indexOf(lowerQuery);

        if (matchIndex === -1) {
            return post.summary || content.slice(0, 120);
        }

        const contextLength = 70;
        const start = Math.max(0, matchIndex - contextLength);
        const end = Math.min(content.length, matchIndex + query.length + contextLength);
        const prefix = start > 0 ? '...' : '';
        const suffix = end < content.length ? '...' : '';
        return `${prefix}${content.slice(start, end).trim()}${suffix}`;
    };

    // 載入搜尋索引
    fetch(searchIndexUrl)
        .then(response => response.json())
        .then(data => {
            posts = data;
        })
        .catch(error => console.error('Error loading search index:', error));

    // 監聽輸入事件
    searchInput.addEventListener('input', function() {
        const rawQuery = this.value.trim();
        const query = rawQuery.toLowerCase();
        
        if (query.length > 0) {
            // 有輸入：隱藏預設列表，顯示搜尋結果
            if (defaultList) defaultList.style.display = 'none';
            searchResults.style.display = 'block';
            searchResults.innerHTML = '';

            const filteredPosts = posts.filter(post => {
                const title = String(post.title || '').toLowerCase();
                const content = String(post.content || '').toLowerCase();
                const tags = post.tags ? post.tags.join(' ').toLowerCase() : '';
                return title.includes(query) || content.includes(query) || tags.includes(query);
            });

            if (filteredPosts.length === 0) {
                searchResults.innerHTML = '<p style="text-align:center; color:var(--text-muted);">找不到相關文章</p>';
                return;
            }

            filteredPosts.forEach(post => {
                const article = document.createElement('article');
                article.className = 'blog-summary';
                
                let tagsHtml = '';
                if (post.tags) {
                    tagsHtml = `<span class="tags">${post.tags.map(tag => `<span class="tag">#${highlightText(tag, rawQuery)}</span>`).join('')}</span>`;
                }

                const snippet = createSnippet(post, rawQuery);

                article.innerHTML = `
                    <h2><a href="${escapeHtml(post.permalink)}">${highlightText(post.title, rawQuery)}</a></h2>
                    <div class="post-meta-list">
                        <time>${escapeHtml(post.date)}</time>
                        ${tagsHtml}
                    </div>
                    <p>${highlightText(snippet, rawQuery)}</p>
                    <a href="${escapeHtml(post.permalink)}" class="read-more">閱讀更多 →</a>
                `;
                searchResults.appendChild(article);
            });
        } else {
            // 無輸入：顯示預設列表，隱藏搜尋結果
            if (defaultList) defaultList.style.display = 'block';
            searchResults.style.display = 'none';
            searchResults.innerHTML = '';
        }
    });
});
