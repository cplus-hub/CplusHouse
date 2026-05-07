## 1. 建立 Archetypes

- [x] 1.1 建立 `archetypes/` 目錄
- [x] 1.2 建立 `archetypes/blog.md`
- [x] 1.3 建立 `archetypes/diary.md`
- [x] 1.4 建立 `archetypes/tech.md`
- [x] 1.5 建立 `archetypes/projects.md`

## 2. 文件更新

- [x] 2.1 在 README 記錄一般部落格文章新增指令
- [x] 2.2 在 README 記錄日記新增指令與月份 `_index.md` 注意事項
- [x] 2.3 在 README 記錄技術筆記新增指令
- [x] 2.4 在 README 記錄作品集新增指令

## 3. 驗證

- [x] 3.1 使用 `hugo new content ... -k blog` 建立臨時文章並檢查 front matter
- [x] 3.2 使用 `hugo new content ... -k diary` 建立臨時日記並檢查 front matter
- [x] 3.3 使用 `hugo new content ... -k tech` 建立臨時技術筆記並檢查 front matter
- [x] 3.4 使用 `hugo new content ... -k projects` 建立臨時作品頁並檢查 front matter
- [x] 3.5 刪除所有臨時測試內容
- [x] 3.6 執行 `hugo -F --destination build-check` 驗證建置
- [x] 3.7 清除 `build-check` 驗證輸出目錄
- [x] 3.8 確認 `git status` 不包含臨時文章、`public/` 或建置輸出
