# PRD: 短期網站維護與內容體驗改善

## 1. 文件資訊

- Change ID: `short-term-site-improvements`
- 狀態: Draft
- 類型: 維護改善、使用者體驗改善、內容結構改善
- 影響範圍: Hugo 設定、GitHub Actions、README、導覽路徑、搜尋功能、技術筆記分類
- 目標版本: 短期改善項目

## 2. 背景

CPlus House 目前是一個可正常建置與部署的 Hugo 靜態網站，包含個人首頁、部落格、日記歸檔、作品集與前端搜尋功能。現階段主要問題不是新增大型功能，而是先消除設定、文件與內容結構的落差，並改善既有搜尋體驗。

目前已知短期問題包含：

- Hugo 本機版本與 GitHub Actions 版本不一致。
- `hugo.toml` 分頁設定與註解不一致。
- README 描述 `content/blog/tech/`，但實際尚未建立技術筆記分類。
- 部分 layout 與文章圖片路徑硬寫 `/CplusHouse`，未來調整部署路徑時風險較高。
- 搜尋結果可找到文章，但沒有關鍵字高亮與命中位置摘要。

## 3. 目標

- 統一路徑、Hugo 版本策略、分頁註解與 README 現況。
- 在搜尋結果中加入關鍵字高亮，並改善摘要呈現。
- 建立或修正技術筆記內容分類，使 README 與實際結構一致。
- 保持 Hugo 靜態網站架構，不導入後端服務或大型前端框架。
- 完成後仍可用 `hugo -F --destination build-check` 成功建置。

## 4. 非目標

- 不重新設計網站視覺。
- 不重構整個 Hugo content 結構。
- 不大量搬移既有日記文章。
- 不導入後端搜尋服務或大型搜尋套件。
- 不做中文斷詞、模糊搜尋或語意搜尋。
- 不建立 placeholder 式假文章內容。

## 5. 使用者故事

- 身為網站維護者，我希望設定、README 與實際目錄一致，避免未來新增內容或部署時踩到隱性問題。
- 身為讀者，我希望搜尋時能看出關鍵字命中位置，快速判斷文章是否符合需求。
- 身為內容作者，我希望技術筆記有固定存放位置與 front matter 慣例。
- 身為協作者，我希望 OpenSpec 與 README 描述的專案狀態符合 repo 實況。

## 6. 功能需求

### 6.1 統一路徑、Hugo 版本、分頁註解與 README 現況

- 應檢查目前專案是否需要 Hugo Extended。
- 應在 README 記錄建議 Hugo 版本。
- 應評估是否將 `.github/workflows/hugo.yaml` 的 `HUGO_VERSION` 更新到與本機一致或專案指定版本。
- `hugo.toml` 的 `pagerSize` 設定與註解需一致。
- `layouts/partials/header.html` 中首頁、部落格、作品集連結應避免硬寫 `/CplusHouse/`。
- `layouts/projects/single.html` 返回作品列表連結應避免硬寫 `/CplusHouse/projects`。
- 文章圖片中硬寫 `/CplusHouse/images/...` 的情況應採用一致策略處理或文件化其部署約束。
- README 的專案結構、執行方式與部署方式需符合目前 repo 狀態。
- `hugo.toml` 中不存在圖片的作品集備援設定應清理、改為存在圖片，或明確標示為範例。

### 6.2 搜尋結果關鍵字高亮與摘要改善

- 使用者輸入關鍵字後，搜尋結果標題、摘要與標籤中符合關鍵字的文字應被高亮。
- 高亮樣式需在淺色與深色模式下都有足夠對比。
- 若文章內文命中關鍵字，摘要應優先擷取命中位置前後文字。
- 摘要長度需固定在合理範圍，避免結果卡片高度過度膨脹。
- 若標題或標籤命中但內文未命中，可退回使用 `post.summary`。
- 搜尋字串前後空白應被忽略，大小寫不敏感比對需維持。
- 特殊字元不應造成正規表示式錯誤。
- 搜尋結果插入 DOM 前應處理 HTML escape，避免直接拼接未處理內容。

### 6.3 技術筆記內容分類

- 應明確建立正式技術筆記分類 `content/blog/tech/`。
- 應建立 `content/blog/tech/_index.md`，至少包含：

```yaml
---
title: "技術筆記"
---
```

- 技術筆記文章建議 front matter：

```yaml
---
title: "文章標題"
date: 2026-05-07
summary: "文章摘要"
tags: ["技術筆記"]
---
```

- 技術筆記應出現在部落格列表頁。
- 技術筆記應被 `layouts/_default/index.json` 收進搜尋索引。
- 技術筆記標籤應出現在標籤雲與標籤時間軸頁。
- README 應提供新增技術筆記的基本步驟。

## 7. 驗收標準

- `hugo -F --destination build-check` 可成功建置。
- 首頁、部落格、作品集、作品詳細頁導覽連結可正常跳轉。
- README 中提到的主要目錄與實際 repo 相符。
- `hugo.toml` 分頁註解與實際設定一致。
- CI Hugo 版本策略在 README 或 workflow 中可被清楚理解。
- 輸入中文、英文或數字關鍵字時，搜尋結果會高亮命中字詞。
- 搜尋結果摘要會優先顯示關鍵字附近內容。
- 清空搜尋框後，預設文章列表恢復顯示。
- 找不到結果時，仍顯示「找不到相關文章」訊息。
- `content/blog/tech/_index.md` 存在，且 Hugo 可建置。
- 不提交 `build-check` 或 `public` 建置輸出。

## 8. 風險與注意事項

- 修改部署路徑或圖片路徑可能影響 GitHub Pages 上既有 URL。
- 更新 Hugo 版本需確認既有 template 語法相容。
- 搜尋索引內容較長時，前端摘要擷取與高亮處理可能增加瀏覽器負擔。
- 若輸出 escape 處理不完整，可能造成 HTML 顯示錯誤或注入風險。
- 新增空分類頁可能出現沒有文章的列表頁，需要確認版型呈現可接受。
- 遠端同時存在 `SIT` 與 `sit` 分支，Windows 環境下需避免分支大小寫混淆。

## 9. 建議實作任務

1. 盤點所有硬寫 `/CplusHouse` 的 layout 與 Markdown 路徑。
2. 決定圖片路徑統一策略。
3. 修正 header、作品返回連結與必要的內容路徑。
4. 修正 `hugo.toml` 分頁註解與作品集備援設定。
5. 更新 README 的專案結構、執行方式、部署方式與技術筆記新增步驟。
6. 視決策更新 `.github/workflows/hugo.yaml` 的 Hugo 版本。
7. 在 `static/js/search.js` 新增 escape HTML、escape RegExp、命中摘要與高亮 helper。
8. 調整搜尋結果 DOM 產生方式。
9. 在 `static/css/style.css` 新增搜尋高亮樣式與深色模式樣式。
10. 新增 `content/blog/tech/_index.md`。
11. 檢查部落格列表、搜尋索引與標籤頁是否包含技術筆記。
12. 執行 Hugo 建置驗證並清除驗證輸出目錄。

