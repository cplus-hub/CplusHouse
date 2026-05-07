# CPlus House

這是一個使用 [Hugo](https://gohugo.io/) 建立的個人作品集與部落格靜態網站。

**線上預覽:** [https://cplus-hub.github.io/CplusHouse](https://cplus-hub.github.io/CplusHouse)

---

## 主要功能

### 設計與使用者體驗

- [x] 現代化簡約設計，專注於內容閱讀。
- [x] 響應式網頁設計，支援桌面、平板與手機。
- [x] 深色/淺色模式切換。
- [x] 回到頂部按鈕。
- [x] 全站側邊欄，包含熱門標籤雲、技術能力與日記歸檔。

### 首頁與作品集

- [x] 個人簡介、社群連結與首頁 Markdown 內容。
- [x] 作品集卡片輪播，優先讀取 `content/projects/` 下的專案內容。
- [x] 最新文章列表。

### 部落格

- [x] Markdown 文章與日記內容管理。
- [x] 日記依年份與月份歸檔，側邊欄自動產生樹狀選單。
- [x] 文章分頁。
- [x] 標籤分類與標籤時間軸頁。
- [x] 前端即時全文搜尋，搜尋來源為 Hugo 產生的 `index.json`。
- [x] 搜尋結果關鍵字高亮與命中位置摘要。
- [x] 上一篇/下一篇導覽。
- [x] 程式碼語法高亮。

---

## 專案結構

```text
.
├── .github/workflows/hugo.yaml   # GitHub Pages 自動部署流程
├── content/                      # Markdown 內容
│   ├── _index.md                 # 首頁內容
│   ├── blog/                     # 部落格根目錄
│   │   ├── diary/                # 生活日記，依年份與月份管理
│   │   └── tech/                 # 技術筆記
│   └── projects/                 # 作品集詳細頁
├── layouts/                      # Hugo 自訂版型
│   ├── _default/                 # 通用頁面、列表、搜尋索引
│   ├── partials/                 # header、footer、sidebar
│   └── projects/                 # 作品集版型
├── static/                       # CSS、JavaScript、圖片
├── openspec/                     # OpenSpec 規格與變更文件
├── hugo.toml                     # Hugo 設定
└── README.md
```

---

## 技術棧

- **靜態網站生成器**: Hugo Extended
- **建議 Hugo 版本**: `0.154.5`
- **前端**: HTML5, CSS3, Vanilla JavaScript
- **內容格式**: Markdown
- **部署**: GitHub Pages + GitHub Actions

本機與 GitHub Actions 目前以 Hugo Extended `0.154.5` 作為驗證版本。

---

## 本地端運行

1. 安裝 Hugo Extended `0.154.5` 或相容版本。
2. 複製專案：

    ```bash
    git clone https://github.com/cplus-hub/CplusHouse.git
    ```

3. 進入專案目錄：

    ```bash
    cd CplusHouse
    ```

4. 啟動本地預覽：

    ```bash
    hugo server -F
    ```

    `-F` 是必要參數，因為日記文章可能包含未來日期；未加上時，Hugo 會隱藏未來日期文章與相關列表。

5. 開啟瀏覽器：

    ```text
    http://localhost:1313/
    ```

正式建置可使用：

```bash
hugo -F --minify
```

---

## 部署方式

推送到 `main` 分支後，GitHub Actions 會執行 `.github/workflows/hugo.yaml`：

1. 安裝 Hugo Extended `0.154.5`。
2. Checkout repo。
3. 使用 GitHub Pages 提供的 base URL 建置網站。
4. 上傳 `public/` artifact。
5. 部署到 GitHub Pages。

`public/` 是建置輸出目錄，已由 `.gitignore` 排除，不應手動提交。

---

## 新增日記

日記路徑採 `年份/月份` 結構：

```text
content/blog/diary/2026/05/day20260507.md
```

月份資料夾需包含 `_index.md`：

```yaml
---
title: "05"
---
```

日記文章 front matter 範例：

```yaml
---
title: "[日記]-2026-05-07"
date: 2026-05-07
author: "CPlus"
tags: ["日記"]
tag_notes:
  日記: "今日紀錄摘要"
---
```

---

## 新增技術筆記

技術筆記放在：

```text
content/blog/tech/
```

技術筆記文章 front matter 範例：

```yaml
---
title: "文章標題"
date: 2026-05-07
summary: "文章摘要"
tags: ["技術筆記"]
---
```

技術筆記會被 Hugo 視為 `blog` section 下的文章，並自動進入部落格列表、搜尋索引與標籤頁。

---

## 圖片路徑約定

- 放在 `static/images/` 的圖片會部署為網站的 `/images/...` 資源。
- 目前既有 Markdown 文章多使用 GitHub Pages 專案路徑，例如 `/CplusHouse/images/nagisa.png`，以維持線上站點圖片可用。
- Layout 與設定檔中的站內連結應使用 Hugo 的 `relURL` 產生，不應硬寫 `/CplusHouse`。
- 未來若要重構文章圖片路徑，建議改用 Hugo shortcode 或一致的資源引用方式，並逐篇抽查。

---

## 未來計畫

- [ ] 增加聯絡表單功能。
- [ ] 進行基礎 SEO 設定。
- [ ] 將文章圖片路徑逐步改成更可攜的 Hugo 資源引用方式。
