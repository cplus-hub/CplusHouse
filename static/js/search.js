document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('search-input');
    const searchResults = document.getElementById('search-results');
    const defaultList = document.getElementById('default-list');
    
    if (!searchInput || !searchResults) return;

    let posts = [];
    // 取得索引檔路徑，若無則預設為 /index.json
    const searchIndexUrl = searchInput.getAttribute('data-search-index') || '/index.json';

    // 載入搜尋索引
    fetch(searchIndexUrl)
        .then(response => response.json())
        .then(data => {
            posts = data;
        })
        .catch(error => console.error('Error loading search index:', error));

    // 監聽輸入事件
    searchInput.addEventListener('input', function() {
        const query = this.value.toLowerCase().trim();
        
        if (query.length > 0) {
            // 有輸入：隱藏預設列表，顯示搜尋結果
            if (defaultList) defaultList.style.display = 'none';
            searchResults.style.display = 'block';
            searchResults.innerHTML = '';

            const filteredPosts = posts.filter(post => {
                const title = post.title.toLowerCase();
                const content = post.content.toLowerCase();
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
                    tagsHtml = `<span class="tags">${post.tags.map(tag => `<span class="tag">#${tag}</span>`).join('')}</span>`;
                }

                article.innerHTML = `
                    <h2><a href="${post.permalink}">${post.title}</a></h2>
                    <div class="post-meta-list">
                        <time>${post.date}</time>
                        ${tagsHtml}
                    </div>
                    <p>${post.summary}</p>
                    <a href="${post.permalink}" class="read-more">閱讀更多 →</a>
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