## Context

CPlus House 目前以 Markdown 維護首頁、部落格、日記、技術筆記與作品集。短期變更已建立 `content/blog/tech/_index.md`，但新增內容時仍需手動撰寫 front matter，日記也需要固定 `tags` 與 `tag_notes` 欄位。這次變更要用 Hugo archetypes 標準化新增內容流程。

目前約束：

- 維持 Hugo 原生 archetype 機制，不引入外部工具。
- 不調整 SEO 或 Google 搜尋收錄相關設定。
- 不新增正式文章或搬移既有內容。
- 測試用臨時內容不得提交。

## Goals / Non-Goals

**Goals:**

- 建立 blog、diary、tech、projects 四種 archetype。
- 讓 `hugo new content ... -k <kind>` 能產生一致 front matter。
- README 記錄各類內容新增指令與注意事項。
- 日記 archetype 固定包含 `tags` 與 `tag_notes`。
- 作品集 archetype 固定包含作品頁需要的欄位。

**Non-Goals:**

- 不調整 SEO、Open Graph、canonical、robots 或 Google 收錄。
- 不建立正式新文章。
- 不重構既有日記文章。
- 不改動作品集資料來源，作品集集中化由 `consolidate-project-content` 處理。

## Decisions

### Decision 1: 使用 Hugo 原生 archetype

採用 `archetypes/*.md`，讓 Hugo 的 `hugo new content ... -k <kind>` 直接產生內容檔。這符合目前專案的 Hugo 靜態網站架構，也不需要額外依賴。

替代方案是自訂腳本產生文章，但會增加維護成本，也會讓新增內容流程脫離 Hugo 原生能力。

### Decision 2: 為不同內容類型建立不同 archetype

建立 `blog.md`、`diary.md`、`tech.md`、`projects.md`。四種內容的欄位需求不同，拆開可以避免單一模板塞入不必要欄位。

### Decision 3: 不在 tech archetype 加 SEO 專用欄位

技術筆記只保留目前內容維護需要的 `title`、`date`、`author`、`summary`、`tags`。不加入 `description`、Open Graph 或 robots 相關欄位，因為目前明確不規劃 SEO。

### Decision 4: 測試 archetype 時使用臨時檔並刪除

實作時需用 `hugo new content` 驗證模板產出，但測試檔不得留下。驗證後只保留 archetype 與 README 變更。

## Risks / Trade-offs

- [Risk] archetype 模板語法錯誤導致 `hugo new content` 失敗 → Mitigation: 每種 kind 都建立臨時內容測試。
- [Risk] 測試內容誤提交 → Mitigation: 驗證後刪除臨時檔，最後檢查 `git status`。
- [Risk] 日記月份 `_index.md` 被誤以為 archetype 會自動建立 → Mitigation: README 明確記錄月份 `_index.md` 仍需存在。
- [Risk] 作品欄位未來與作品集集中化需求不一致 → Mitigation: 先以目前 `layouts/projects/single.html` 需要的欄位為準。

## Migration Plan

1. 新增 `archetypes/` 與四個 archetype。
2. 更新 README 新增內容指令。
3. 建立臨時內容測試 archetype 產出。
4. 刪除臨時測試內容。
5. 執行 Hugo 建置驗證。

## Open Questions

- 是否要將日記檔名格式固定為 `dayYYYYMMDD.md`，或只在 README 中建議？
- 作品集 `image` 預設值是否保留 `images/care.png`，或改成空字串讓作者必填？
