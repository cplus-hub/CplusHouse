## Context

CPlus House 是 Hugo 靜態網站，內容由 Markdown 管理，版型集中在 `layouts/`，樣式與搜尋腳本集中在 `static/`。本次變更橫跨設定、部署文件、導覽路徑、搜尋體驗與內容分類，因此需要先固定實作邊界，避免短期維護項目彼此衝突。

目前主要約束：

- 必須維持 Hugo 靜態網站架構，不新增後端或前端框架。
- 本地預覽需保留 `hugo server -F`，因為日記內容可能包含未來日期。
- `public/` 與驗證輸出目錄不可提交。
- 導覽、搜尋與內容分類應沿用既有 `layouts`、`static/js/search.js`、`static/css/style.css` 模式。

## Goals / Non-Goals

**Goals:**

- 讓 Hugo 版本、分頁設定、README 與實際 repo 狀態一致。
- 降低硬寫 `/CplusHouse` 對本地預覽與未來部署路徑調整的影響。
- 讓搜尋結果能清楚顯示命中關鍵字與命中附近摘要。
- 建立正式技術筆記分類，並讓其自然被部落格、搜尋與標籤機制收錄。
- 完成後可用 Hugo 建置驗證。

**Non-Goals:**

- 不重做網站 UI。
- 不重構整個內容目錄。
- 不搬移既有日記文章。
- 不導入 Lunr、Fuse、Algolia 或其他搜尋服務。
- 不做中文斷詞、模糊搜尋或語意搜尋。

## Decisions

### Decision 1: 先統一 layout 路徑，Markdown 圖片採盤點後漸進處理

Layout 內部導覽連結應改用 Hugo 能依 `baseURL` 產生正確 URL 的方式，例如 `relURL` 搭配不含 `/CplusHouse` 的站內路徑。Markdown 文章中的圖片路徑數量較多，且目前線上 GitHub Pages 依賴 `/CplusHouse/images/...`，因此不應在沒有驗證的情況下一次性改動所有圖片。

替代方案：

- 全部圖片路徑立即改為相對路徑。風險是不同文章層級會需要不同 `../` 深度，容易產生破圖。
- 全部改為 shortcode。長期乾淨，但短期改動面較大。

本次採用：layout 連結優先修正；Markdown 圖片先盤點並選擇安全策略，若批次修改，需以本地建置與頁面抽查驗證。

### Decision 2: 搜尋維持純前端 substring match

既有搜尋已由 Hugo 產生 `index.json`，再由 `static/js/search.js` 載入並比對標題、內文與標籤。本次只在此架構上增加高亮與命中摘要，不新增搜尋依賴。

替代方案：

- 使用 Fuse.js 或 Lunr。可以提供更強搜尋能力，但會增加依賴與維護成本。
- 後端搜尋。與靜態網站部署模式不符。

本次採用：維持大小寫不敏感的 substring match，新增 escape helper、命中摘要 helper 與高亮 helper。

### Decision 3: 搜尋結果輸出需先處理 escape

目前搜尋結果透過 template string 組出 HTML。加入高亮後會更常處理使用者輸入與文章文字，因此必須先 escape 文章資料與查詢字串，再插入高亮標記，避免特殊字元破壞 HTML 或正規表示式。

替代方案：

- 完全改用 DOM API 建立節點。安全性較好，但會讓既有程式改動較大。
- 保持現況直接 `innerHTML`。改動少，但高亮功能會放大注入與顯示錯誤風險。

本次採用：建立 `escapeHtml` 與 `escapeRegExp`，在保留既有渲染結構的前提下降低風險。

### Decision 4: 技術筆記建立分類骨架，不新增假文章

README 已把技術筆記視為部落格分類，因此本次建立 `content/blog/tech/_index.md` 作為正式分類入口。為避免 placeholder 被誤認為正式內容，本次不建立範例技術文章，僅在 README 文件化新增文章格式。

替代方案：

- 只改 README 移除技術筆記。會降低未來擴充成本，但不符合網站展示學習筆記的方向。
- 新增範例文章。可立即驗證列表與搜尋，但容易污染正式內容。

本次採用：建立分類骨架與文件，不新增假文章。

### Decision 5: Hugo 版本以文件化與 CI 明確化為優先

本機已確認 Hugo `0.154.5`，GitHub Actions 使用 `0.128.0`。本次應選定一個專案建議版本並在 README 與 workflow 中保持一致，或明確記錄最低支援版本與測試版本。

替代方案：

- 只更新 README，不碰 CI。風險是部署仍可能與本機不同。
- 直接追最新 Hugo。風險是未來不可預期變更。

本次採用：以目前本機驗證版本作為候選版本，實作時需確認 CI 安裝方式仍可取得該版本。

## Risks / Trade-offs

- [Risk] Markdown 圖片路徑批次修改造成線上破圖 → Mitigation: 先盤點，優先修正 layout 路徑；若改文章圖片，需抽查代表性文章。
- [Risk] Hugo 版本更新後 template 行為差異 → Mitigation: 更新後執行 `hugo -F --destination build-check`。
- [Risk] 搜尋高亮處理長內容造成前端負擔 → Mitigation: 摘要擷取限制字數，只對顯示片段做高亮。
- [Risk] escape 流程不完整造成 HTML 顯示錯誤 → Mitigation: 搜尋輸入、標題、摘要與標籤分別用 helper 處理。
- [Risk] 空技術筆記分類頁顯示體驗不佳 → Mitigation: 確認 Hugo 產生頁面可接受，README 說明分類已建立但文章可後續新增。

## Migration Plan

1. 先完成設定與文件調整，再處理搜尋與內容分類。
2. 修改後執行 Hugo 建置驗證。
3. 驗證通過後清除 `build-check`。
4. 若發現路徑修改造成破圖，回退該批 Markdown 圖片修改，保留 layout 連結修正。

## Open Questions

- 是否要將 GitHub Actions Hugo 版本直接更新為 `0.154.5`，或只記錄本機測試版本並維持 CI 版本？
- Markdown 圖片路徑是否要在本次全部改成 shortcode，或只文件化目前 GitHub Pages 專案路徑約束？

