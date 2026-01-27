# 個人作品集網站 (Personal Portfolio Website)

這是一個基於 **Hugo** 靜態網站生成器構建的個人作品集網站。專案採用類似 MVC 的架構設計，並整合了現代化的前端功能，旨在提供一個高效、易維護且美觀的個人展示平台。

## ✨ 功能特色

*   **現代簡約風格**：採用乾淨的卡片式設計與配色。
*   **暗黑模式 (Dark Mode)**：支援一鍵切換日/夜間模式，並自動記憶使用者偏好。
*   **響應式設計 (RWD)**：完美支援手機、平板與桌機瀏覽。
*   **作品集輪播**：首頁包含互動式的作品集展示區塊，支援觸控滑動。
*   **MVC 架構思維**：
    *   **Model**: `content/` (Markdown 資料) & `hugo.toml` (設定)
    *   **View**: `layouts/` (HTML 模板)
    *   **Controller**: Hugo 核心引擎
*   **自動化部署**：整合 GitHub Actions，Push 即自動發布至 GitHub Pages。

## 📂 專案結構

本專案遵循 Hugo 標準目錄結構，並對應 MVC 邏輯：

```text
CplusHouse/
├── content/                # [Model] 網站內容 (Markdown)
│   └── _index.md           # 首頁文字內容
├── layouts/                # [View] HTML 模板
│   ├── _default/
│   │   └── baseof.html     # 基礎佈局 (Header, Footer)
│   └── index.html          # 首頁專用模板
├── static/                 # [Assets] 靜態資源
│   ├── css/
│   │   └── style.css       # 全站樣式表
│   └── images/             # 圖片檔案
├── .github/
│   └── workflows/
│       └── hugo.yaml       # GitHub Actions 自動部署腳本
└── hugo.toml               # [Config] 網站核心設定
```

## 🚀 快速開始

### 前置需求
請確保您的電腦已安裝 Hugo (建議安裝 Extended 版本)。

### 本地開發
1.  **啟動伺服器**
    ```bash
    hugo server
    ```

2.  **預覽網站**
    打開瀏覽器訪問 `http://localhost:1313`。

## ⚙️ 網站設定

所有個人資訊與作品資料皆可在 `hugo.toml` 中進行設定，無需修改 HTML。

### 修改個人資訊
```toml
[params]
  author = "您的名字"
  bio = "您的個人簡介..."
  github = "https://github.com/..."
  email = "mailto:..."
```

### 新增作品
在 `hugo.toml` 的 `[[params.projects]]` 區塊中新增：
```toml
[[params.projects]]
  title = "專案名稱"
  description = "專案描述"
  image = "/images/your-image.jpg" # 請將圖片放入 static/images/
  link = "專案連結"
```

## 📦 部署至 GitHub Pages

本專案已設定好 GitHub Actions，部署流程完全自動化。

1.  **修改 `hugo.toml`**：
    將 `baseURL` 修改為您 GitHub Pages 的網址：
    ```toml
    baseURL = 'https://您的帳號.github.io/專案名稱/'
    ```

2.  **推送到 GitHub**：
    ```bash
    git add .
    git commit -m "Update site content"
    git push origin main
    ```

3.  **設定 GitHub Pages**：
    *   進入 GitHub Repository 的 **Settings** > **Pages**。
    *   在 **Build and deployment** > **Source** 選擇 **GitHub Actions**。

等待約 1 分鐘，您的網站就會自動上線！
