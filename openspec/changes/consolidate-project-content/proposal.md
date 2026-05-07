## Why

目前作品集資料同時存在 `hugo.toml` 的 `params.projects` 與 `content/projects`，容易造成首頁、作品列表與作品詳細頁資料來源不一致。將作品集集中由 Markdown 維護，可以讓每個專案都有完整內容、圖片、技術堆疊與功能列表，並降低重複維護成本。

## What Changes

- 盤點 `hugo.toml` 的 `params.projects` 與 `content/projects` 既有資料。
- 定義作品集 front matter 標準欄位，包含 `title`、`date`、`description`、`image`、`dev_time`、`tech_stack`、`features`。
- 將正式作品資料集中維護於 `content/projects`。
- 調整首頁作品集區塊，使資料來源以 `content/projects` 為主。
- 調整或確認 `/projects/` 列表頁與作品詳細頁顯示完整 Markdown、圖片、技術堆疊、開發時間與功能列表。
- 移除、降級或明確標示 `hugo.toml` 中的 `params.projects` fallback。
- 更新 README，記錄新增作品集文章方式、front matter 欄位與圖片引用方式。
- 非目標: 不調整 SEO、不加入 Google 搜尋收錄最佳化、不重設作品集視覺設計、不大幅改動非作品集內容。

## Capabilities

### New Capabilities

- `project-content`: 定義作品集 Markdown 內容模型、列表/首頁資料來源、詳細頁顯示需求與文件化需求。

### Modified Capabilities

- 無。`openspec/specs/` 目前沒有既有 capability，本變更會建立新的 capability spec。

## Impact

- 影響設定: `hugo.toml` 的 `params.projects`。
- 影響內容: `content/projects/`。
- 影響版型: `layouts/index.html`、`layouts/projects/list.html`、`layouts/projects/single.html`。
- 影響文件: `README.md`。
- 影響頁面: 首頁作品區、`/projects/`、作品詳細頁。
- 風險: 若移除 fallback 或改變作品資料來源，首頁作品輪播可能在資料不足時變空；圖片引用方式需避免打破現有 GitHub Pages 路徑。
