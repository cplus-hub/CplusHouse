## 1. 設定與路徑盤點

- [x] 1.1 檢查本機 Hugo 版本、GitHub Actions `HUGO_VERSION` 與 README 版本描述是否一致
- [x] 1.2 盤點 `layouts/` 中硬寫 `/CplusHouse` 的站內連結
- [x] 1.3 盤點 `content/` 中硬寫 `/CplusHouse/images/` 的 Markdown 圖片路徑
- [x] 1.4 決定 Markdown 圖片路徑採批次修正或文件化部署約束

## 2. 設定與文件一致性

- [x] 2.1 修正 `hugo.toml` 的 `pagerSize` 註解，使其與實際設定一致
- [x] 2.2 修正 header 與作品詳細頁返回連結，避免 layout 硬寫 `/CplusHouse`
- [x] 2.3 清理、修正或標示 `hugo.toml` 中不存在圖片的作品集備援設定
- [x] 2.4 更新 README 的專案結構、本地執行方式、部署方式與 Hugo 版本策略
- [x] 2.5 依已決定策略處理或記錄 Markdown 圖片路徑約束

## 3. 搜尋結果改善

- [x] 3.1 在 `static/js/search.js` 新增 `escapeHtml` 與 `escapeRegExp` helper
- [x] 3.2 新增搜尋命中摘要擷取 helper，優先顯示關鍵字附近文字
- [x] 3.3 新增搜尋結果高亮 helper，支援標題、摘要與標籤
- [x] 3.4 調整搜尋結果渲染流程，避免直接插入未處理的文章內容或使用者輸入
- [x] 3.5 在 `static/css/style.css` 新增搜尋高亮樣式與深色模式樣式
- [x] 3.6 手動驗證中文、英文、數字、特殊字元、無結果與清空輸入情境

## 4. 技術筆記分類

- [x] 4.1 建立 `content/blog/tech/_index.md`
- [x] 4.2 在 README 新增技術筆記文章 front matter 範例
- [x] 4.3 確認技術筆記分類可被 Hugo 視為 `blog` section 下的內容
- [x] 4.4 確認不新增 placeholder 文章也能完成 Hugo 建置

## 5. 驗證與收尾

- [x] 5.1 執行 `hugo -F --destination build-check` 驗證建置
- [x] 5.2 抽查首頁、部落格、作品集、作品詳細頁與搜尋頁的主要連結
- [x] 5.3 抽查至少一篇含圖片文章，確認代表性圖片仍可載入
- [x] 5.4 清除 `build-check` 驗證輸出目錄
- [x] 5.5 確認 `git status` 不包含 `public/` 或建置輸出
