# 個人網站專案規劃

本專案旨在建立一個託管於 GitHub Pages 的個人網站，整合作品集、個人資訊與部落格功能。

## 專案需求規格

根據需求定義，本專案將遵循以下規範進行開發：

1.  **技術架構 (Framework)**
    *   專案必須使用框架進行建置（例如：Hexo, Hugo, Jekyll 或 Vue/React 相關靜態生成器），以確保程式碼結構化與可維護性。

2.  **網站用途**
    *   **作品呈現**: 展示過往專案、程式碼與設計成果。
    *   **個人資訊**: 包含自我介紹、技能樹與聯絡方式。
    *   **部落格**: 用於發表技術文章或生活紀錄。

3.  **部署平台**
    *   網站成品須部署至 **GitHub Pages**。

4.  **語言規範**
    *   全站內容與介面須完全使用 **繁體中文**。

## 技術架構選型

本專案已確定採用 **Hugo** (Go語言開發的靜態網站生成器) 進行開發。

### 選擇原因
1.  **高維護性**：單一執行檔，無複雜依賴環境，避免長期閒置後無法運作的問題。
2.  **高效能**：頁面生成速度極快。
3.  **結構清晰**：內容 (Markdown) 與版型 (Layouts) 分離。

## 專案結構說明

*   `hugo.toml`: 網站核心設定檔。
*   `content/`: 存放網站內容 (Markdown)。
    *   `_index.md`: 首頁內容。
*   `layouts/`: 存放 HTML 模板。
    *   `index.html`: 首頁 HTML 結構。

## 開發指令

1.  安裝 Hugo (請參考官方文件)。
2.  啟動本地伺服器：
    ```bash
    hugo server
    ```
3.  瀏覽網站：開啟瀏覽器訪問 `http://localhost:1313`

## 部署至 GitHub Pages

本專案已設定 GitHub Actions 自動化部署，請依照以下步驟啟用：

1.  **修改設定檔**：
    *   開啟 `hugo.toml`，將 `baseURL` 修改為您實際的 GitHub Pages 網址（例如：`https://您的帳號.github.io/專案名稱/`）。
2.  **上傳程式碼**：
    *   將專案 Push 到 GitHub Repository 的 `main` 分支。
3.  **啟用 Pages**：
    *   進入 GitHub Repo 的 **Settings** > **Pages**。
    *   在 **Build and deployment** 區塊，將 Source 改為 **GitHub Actions**。
4.  **完成**：
    *   等待 Actions 執行完畢（約 1 分鐘），您的網站就會上線了。
