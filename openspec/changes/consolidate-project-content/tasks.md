## 1. 作品資料盤點

- [x] 1.1 盤點 `hugo.toml` 中的 `params.projects`
- [x] 1.2 盤點 `content/projects/` 既有作品 Markdown
- [x] 1.3 判斷 `params.projects` 中各項資料是正式作品或備援範例
- [x] 1.4 確認首頁、作品列表與作品詳細頁目前使用的欄位

## 2. 內容集中化

- [x] 2.1 定義並套用作品集 front matter 標準欄位
- [x] 2.2 將正式作品資料建立或補齊到 `content/projects/*.md`
- [x] 2.3 移除、降級或明確標示 `hugo.toml` 的 `params.projects` fallback
- [x] 2.4 確認 `content/projects` 至少保留一筆可顯示作品

## 3. 版型與文件

- [x] 3.1 確認首頁作品區以 `content/projects` 為主要資料來源
- [x] 3.2 確認 `/projects/` 作品列表顯示 Markdown 作品資料
- [x] 3.3 確認作品詳細頁顯示圖片、開發時間、技術堆疊、Markdown 內容與功能列表
- [x] 3.4 更新 README 的作品集新增方式與 front matter 說明
- [x] 3.5 更新 README 的作品圖片放置與引用說明

## 4. 驗證

- [x] 4.1 執行 `hugo -F --destination build-check` 驗證建置
- [x] 4.2 抽查首頁作品區
- [x] 4.3 抽查 `/projects/`
- [x] 4.4 抽查至少一個作品詳細頁
- [x] 4.5 清除 `build-check` 驗證輸出目錄
- [x] 4.6 確認 `git status` 不包含 `public/` 或建置輸出
