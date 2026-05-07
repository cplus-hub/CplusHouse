## Why

專案目前能正常建置，但 Hugo 版本策略、README、分頁註解、部分路徑與內容分類存在不一致，同時既有搜尋結果缺少命中提示。這些問題會增加後續維護成本，也降低讀者搜尋文章時的判斷效率，因此應在短期內整併處理。

## What Changes

- 統一或明確文件化本機與 GitHub Actions 的 Hugo 版本策略。
- 修正 `hugo.toml` 中 `pagerSize` 設定與註解不一致的問題。
- 調整 layout 中硬寫 `/CplusHouse` 的導覽與返回連結，改為符合 Hugo baseURL 的路徑產生方式。
- 盤點文章圖片中硬寫 `/CplusHouse/images/...` 的情況，採用一致策略處理或文件化其部署約束。
- 清理或標示 `hugo.toml` 中不存在的作品圖片備援設定，例如 `project2.jpg`、`project3.jpg`。
- 更新 README，使專案結構、執行方式、部署方式與技術筆記分類符合目前 repo 狀態。
- 建立正式技術筆記分類 `content/blog/tech/` 與必要 `_index.md`。
- 定義技術筆記文章 front matter 慣例，並確認技術筆記可被部落格列表、搜尋索引與標籤頁收錄。
- 在搜尋結果標題、摘要與標籤中高亮使用者輸入的關鍵字。
- 搜尋摘要改為優先擷取文章內文命中位置前後內容。
- 強化搜尋字串與輸出文字處理，避免特殊字元造成正規表示式錯誤，並降低直接拼接 HTML 的風險。
- 非目標: 不重新設計網站視覺，不重構整個 content 結構，不大量搬移既有日記文章，不導入後端搜尋服務或大型搜尋套件。

## Capabilities

### New Capabilities

- `site-config-consistency`: 定義 Hugo 設定、部署版本、站內路徑、資源引用與 README 文件一致性的維護需求。
- `site-search-results`: 定義站內搜尋結果的命中顯示、摘要擷取、高亮樣式、輸入處理與安全輸出需求。
- `tech-notes-content`: 定義技術筆記內容分類、文章 front matter、列表可見性、搜尋索引收錄與文件化需求。

### Modified Capabilities

- 無。`openspec/specs/` 目前沒有既有 capability，本變更會建立新的 capability specs。

## Impact

- 影響設定: `hugo.toml`。
- 影響部署流程: `.github/workflows/hugo.yaml`。
- 影響版型: `layouts/partials/header.html`、`layouts/projects/single.html`，可能包含搜尋相關 list/search template。
- 影響腳本: `static/js/search.js`。
- 影響樣式: `static/css/style.css`。
- 影響內容: `content/blog/tech/`，以及可能涉及 Markdown 圖片路徑。
- 影響文件: `README.md`。
- 影響頁面: 首頁、部落格列表、站內搜尋頁、作品集、作品詳細頁、標籤頁與含圖片文章。
- 風險: 修改部署路徑或圖片路徑可能影響 GitHub Pages 上既有 URL；更新 Hugo 版本需確認既有 template 語法相容；搜尋高亮若 escape 處理不完整，可能造成 HTML 顯示錯誤或注入風險。

