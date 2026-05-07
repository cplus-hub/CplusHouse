# 中期網站改善規劃

## 文件資訊

- 文件類型: Roadmap / Implementation Outline
- 狀態: Draft
- 範圍: 作品集內容集中化、內容 archetype
- 明確排除: SEO / Google 搜尋收錄最佳化
- 建議拆分 change:
  - `add-content-archetypes`
  - `consolidate-project-content`

## 決策記錄: 不規劃 SEO 類型變更

目前不打算將網站主動提交或優化給 Google 搜尋收錄，因此中期規劃不包含 SEO 類型工作。

已移除的項目：

- SEO 基礎設定
- `description` metadata 規劃
- Open Graph metadata 規劃
- canonical URL 規劃
- robots.txt / sitemap 最佳化規劃
- 文章圖片 metadata 規劃
- `add-seo-baseline` OpenSpec change 建議

保留原則：

- 網站仍可保留基本 `<title>`，供瀏覽器分頁顯示。
- 若 Hugo 預設產生 RSS 或 sitemap，不在本規劃中額外強化或最佳化。
- 若未來需求改變，再另開獨立 change 討論 SEO 或 noindex 控制。

## 建議實作順序

建議優先順序：

1. `add-content-archetypes`
2. `consolidate-project-content`

原因：

- archetype 會先定義穩定的 front matter 欄位。
- 作品集集中化需要依賴一致的作品 front matter schema。
- 先建立新增內容模板，可降低後續新增日記、技術筆記與作品時的欄位落差。

---

## 1. 建立內容 Archetypes

### 目標

建立標準化內容模板，讓日記、技術筆記、一般部落格文章與作品集在新增時自動帶出一致 front matter。

### 涵蓋項目

- `archetypes/blog.md`
- `archetypes/diary.md`
- `archetypes/tech.md`
- `archetypes/projects.md`
- README 新增內容指令

### 預計詳細步驟

1. 建立 archetypes 目錄

   ```text
   archetypes/
   ```

2. 建立一般部落格文章 archetype

   `archetypes/blog.md`：

   ```yaml
   ---
   title: "{{ replace .File.ContentBaseName "-" " " | title }}"
   date: {{ .Date }}
   author: "CPlus"
   summary: ""
   tags: []
   ---
   ```

3. 建立日記 archetype

   `archetypes/diary.md`：

   ```yaml
   ---
   title: "[日記]-{{ .Date.Format "2006-01-02" }}"
   date: {{ .Date }}
   author: "CPlus"
   tags: ["日記"]
   tag_notes:
     日記: ""
   ---
   ```

4. 建立技術筆記 archetype

   `archetypes/tech.md`：

   ```yaml
   ---
   title: "{{ replace .File.ContentBaseName "-" " " | title }}"
   date: {{ .Date }}
   author: "CPlus"
   summary: ""
   tags: ["技術筆記"]
   ---
   ```

5. 建立作品集 archetype

   `archetypes/projects.md`：

   ```yaml
   ---
   title: "{{ replace .File.ContentBaseName "-" " " | title }}"
   date: {{ .Date }}
   description: ""
   image: "images/care.png"
   dev_time: ""
   tech_stack: []
   features: []
   ---
   ```

6. 更新 README 新增內容指令
   - 技術筆記：

     ```bash
     hugo new content blog/tech/my-note.md -k tech
     ```

   - 作品集：

     ```bash
     hugo new content projects/my-project.md -k projects
     ```

   - 日記：

     ```bash
     hugo new content blog/diary/2026/05/day20260507.md -k diary
     ```

   - 補充日記月份 `_index.md` 仍需存在。

7. 驗證 archetype 產出
   - 使用 `hugo new content` 建立臨時測試文章。
   - 檢查 front matter 是否符合預期。
   - 刪除臨時測試文章。
   - 執行 Hugo 建置。

8. 收尾
   - 確認沒有測試文章殘留。
   - 確認 `public/`、`build-check/` 未被提交。

### 驗收標準

- `archetypes/` 目錄存在。
- blog、diary、tech、projects archetype 都可用。
- 使用 `hugo new content ... -k <kind>` 能產出完整 front matter。
- README 記錄新增內容指令。
- Hugo 建置成功。

---

## 2. 作品集資料集中到 `content/projects`

### 目標

讓作品集資料集中由 Markdown 維護，避免 `hugo.toml` 與 `content/projects` 兩邊資料重複或不一致。

### 涵蓋項目

- 作品集 front matter schema
- 首頁作品輪播資料來源
- 作品列表頁
- 作品詳細頁
- 移除或降級 `params.projects`

### 預計詳細步驟

1. 盤點目前作品集資料來源
   - 檢查 `hugo.toml` 的 `params.projects`
   - 檢查 `content/projects/care.md`
   - 檢查 `layouts/index.html`
   - 檢查 `layouts/projects/list.html`
   - 檢查 `layouts/projects/single.html`

2. 定義作品集 front matter schema
   - 建議標準：

     ```yaml
     ---
     title: "專案名稱"
     date: 2026-05-07
     description: "短描述"
     image: "images/care.png"
     dev_time: "2021/10 - 2026/02"
     tech_stack: ["PHP", "MySQL", "jQuery"]
     features:
       - title: "功能名稱"
         description: "功能描述"
     ---
     ```

3. 將作品資料集中到 Markdown
   - 既有 `Care 關心` 繼續放在 `content/projects/care.md`
   - 若 `hugo.toml` 的其他作品是正式資料，需建立對應 Markdown：
     - `content/projects/community-management.md`
     - `content/projects/course-platform.md`
   - 若只是範例資料，應移除或在 README 註明為備援範例。

4. 調整首頁作品集邏輯
   - 讓首頁優先且主要讀取 `content/projects`
   - 評估是否完全移除 `params.projects` fallback
   - 若保留 fallback，需在註解與 README 中明確說明用途。

5. 調整作品列表頁
   - 確認 `/projects/` 顯示所有 `content/projects` 文章
   - 確認圖片、標題、描述、連結正常
   - 若沒有作品，需有合理空狀態或不顯示空 grid。

6. 調整作品詳細頁
   - 確認顯示：
     - title
     - dev_time
     - tech_stack
     - image
     - Markdown content
     - features
   - 確認返回作品列表連結正確支援 GitHub Pages baseURL。

7. 更新 README
   - 說明新增作品集文章方式
   - 說明作品集 front matter 欄位
   - 說明圖片放置與引用方式。

8. 驗證
   - 執行：

     ```bash
     hugo -F --destination build-check
     ```

   - 抽查：
     - 首頁作品區
     - `/projects/`
     - `/projects/care/`
   - 清除 `build-check`。

### 驗收標準

- 首頁作品集資料來自 `content/projects`。
- `/projects/` 正常列出所有作品。
- 單一作品頁能顯示完整 Markdown、圖片、技術堆疊、開發時間與功能列表。
- `hugo.toml` 不再含有容易誤用的正式作品資料重複來源，或已明確標記為 fallback。
- Hugo 建置成功。

---

## OpenSpec 拆分建議

若進入正式 OpenSpec 流程，建議建立兩個 change：

### `add-content-archetypes`

優先處理內容欄位標準化。

輸出 artifacts：

- `proposal.md`
- `design.md`
- `specs/content-archetypes/spec.md`
- `tasks.md`

### `consolidate-project-content`

整理作品集資料來源。

輸出 artifacts：

- `proposal.md`
- `design.md`
- `specs/project-content/spec.md`
- `tasks.md`

## 風險與注意事項

- 作品集資料來源調整可能影響首頁作品輪播與 `/projects/` 頁。
- archetype 測試時產生的臨時內容不能提交。
- 若調整圖片引用方式，需避免打破現有 GitHub Pages 圖片路徑。
- 本 roadmap 已排除 SEO；若未來要處理 Google 收錄、Open Graph、canonical 或 robots，需另開獨立規格重新討論。
