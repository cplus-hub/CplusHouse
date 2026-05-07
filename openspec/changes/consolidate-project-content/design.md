## Context

作品集目前有兩個資料來源：`content/projects/care.md` 與 `hugo.toml` 的 `params.projects`。首頁版型已優先讀取 `content/projects`，但仍保留 config fallback。這會讓正式作品資料可能分散在設定檔與 Markdown，後續維護時容易不一致。

目前約束：

- 作品集內容應集中到 `content/projects`。
- 沿用既有 `layouts/index.html`、`layouts/projects/list.html`、`layouts/projects/single.html`。
- 不重新設計作品集視覺。
- 不調整 SEO 或 Google 搜尋收錄。

## Goals / Non-Goals

**Goals:**

- 定義作品集 Markdown front matter schema。
- 將正式作品資料集中在 `content/projects`。
- 讓首頁作品區、`/projects/`、作品詳細頁都以 Markdown 內容為主要來源。
- 移除或明確降級 `hugo.toml` 的 `params.projects` fallback。
- README 記錄作品新增方式與欄位。

**Non-Goals:**

- 不調整 SEO、Open Graph、canonical、robots 或 Google 收錄。
- 不重設作品集 UI。
- 不改動非作品集內容。
- 不新增與作品無關的資料模型。

## Decisions

### Decision 1: `content/projects` 作為正式資料來源

正式作品資料應維護於 Markdown，因為作品詳細頁本身也需要 Markdown 內容、front matter、圖片、技術堆疊與功能列表。這比把正式資料放在 `hugo.toml` 更可維護。

### Decision 2: `params.projects` 只作為 fallback 或移除

如果 `content/projects` 有資料，首頁與作品列表應使用 `content/projects`。`params.projects` 若保留，只能作為沒有 content projects 時的備援範例，並需在註解或 README 中說明。

### Decision 3: 作品 front matter 對齊現有作品詳細頁

欄位以目前 `layouts/projects/single.html` 已使用的資料為準：

- `title`
- `date`
- `description`
- `image`
- `dev_time`
- `tech_stack`
- `features`

### Decision 4: 不加入 SEO 圖片 metadata

`image` 只作為作品卡片與作品詳細頁顯示圖片，不作為 SEO 或社群分享 metadata 規劃。

## Risks / Trade-offs

- [Risk] 移除 config fallback 後首頁作品區變空 → Mitigation: 先確認 `content/projects` 至少有一筆正式作品。
- [Risk] 轉換 config 作品資料時產生不完整內容 → Mitigation: 若資料只是範例，不轉正式作品；若是正式作品，補足 Markdown 內容。
- [Risk] 圖片路徑變更造成破圖 → Mitigation: 使用既有 `static/images` 資源並執行 Hugo 建置抽查。
- [Risk] 首頁與列表頁資料排序改變 → Mitigation: 明確使用 Hugo 頁面日期排序或既有排序規則。

## Migration Plan

1. 盤點 `params.projects` 與 `content/projects`。
2. 判斷 config 中各項作品是正式資料或範例資料。
3. 將正式資料轉成 `content/projects/*.md`。
4. 調整首頁與作品頁資料來源。
5. 更新 README。
6. 執行 Hugo 建置與頁面抽查。

## Open Questions

- `params.projects` 是否要完全移除，或保留作為無內容時的 fallback？
- `hugo.toml` 中目前另外兩個作品項目是否是正式作品，還是只作為範例資料？
