# Listview
圖書管理與借閱模擬程式 (Library Management System)
這是一個基於 Windows Forms (C# .NET Framework) 開發的單機版圖書管理與模擬借閱程式。本專案透過 ListView 元件展示館藏圖書，並提供多種視覺化檢視切換，同時整合了完整的借閱清單互動功能。

🚀 功能特點
多功能檢視切換：支援 5 種不同的圖書瀏覽模式（大圖示、詳細資料、小圖示、清單、大圖示加詳細資料/Tile）。

動態佈局優化：程式全面採用 Dock 與 Panel 容器管理，並開啟 AutoArrange 與 Scrollable 屬性。當視窗縮放時，書籍圖示會自動換行並提供滾動條，確保畫面不破圖。

互動式借閱機制：

使用者可以點擊列表中的書籍。

系統會自動防呆，檢查該書籍是否已存在於借閱清單中。

當確認借閱後，書籍會即時同步至右側的「借書清單 (ListBox)」中。

開發環境與架構
開發語言：C#

視窗技術：Windows Forms (.NET Framework)

重要元件與屬性設定：

ListView (lvwBooks)：Scrollable = true, AutoArrange = true

ImageList (imgL / imgS)：用於存放書籍的 BMP 格式封面大/小圖示。

檔案結構
lstBorrow.cs：主程式邏輯，包含資料初始化、檢視切換事件以及借閱清單的互動邏輯。

lstBorrow.Designer.cs：視窗元件配置與佈局程式碼（由 Visual Studio 設計工具自動與手動優化產生）。
<img width="745" height="484" alt="image" src="https://github.com/user-attachments/assets/278f1602-ebbd-4960-b5e3-bef0f73cef47" />
