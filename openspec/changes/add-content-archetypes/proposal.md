## Why

目前新增日記、技術筆記、一般部落格文章與作品集時，需要手動撰寫 front matter，容易產生欄位缺漏或格式不一致。建立 Hugo archetypes 可以讓新增內容時自動帶出標準欄位，降低後續維護成本。

## What Changes

- 新增 `archetypes/` 目錄。
- 建立一般部落格文章 archetype：`archetypes/blog.md`。
- 建立日記 archetype：`archetypes/diary.md`。
- 建立技術筆記 archetype：`archetypes/tech.md`。
- 建立作品集 archetype：`archetypes/projects.md`。
- 更新 README，記錄各類內容的 `hugo new content ... -k <kind>` 建立方式。
- 驗證 archetype 產出的 front matter 是否符合預期。
- 非目標: 不調整 SEO、不加入 Google 搜尋收錄最佳化、不新增正式文章內容、不重構既有日記文章。

## Capabilities

### New Capabilities

- `content-archetypes`: 定義 blog、diary、tech、projects 內容模板、必要 front matter 欄位與新增內容指令。

### Modified Capabilities

- 無。`openspec/specs/` 目前沒有既有 capability，本變更會建立新的 capability spec。

## Impact

- 影響新增目錄: `archetypes/`。
- 影響文件: `README.md`。
- 影響工作流程: 新增內容時改用 `hugo new content ... -k <kind>` 產生標準 front matter。
- 影響驗證: 需建立臨時測試內容確認 archetype 可用，測試內容不得提交。
- 風險: archetype 測試時產生的臨時文章若未刪除，可能誤入正式內容；日記仍需保留月份 `_index.md` 的既有規則。
