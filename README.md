# H'Style 精品服飾網站

**Keyword: ASP.NET MVC、ASP.NET Core、WebAPi、三層式架構(表現層、業務邏輯層、資料存取層)、Vue3 composition API、前後端分離**  
- 此為多人合作專案(6人)
- 專案理念: 針對中高端客群精品消費需求所設計，向消費者提供更全方位的服務，如個人專屬推薦、建立自媒體及客戶關係的管理等
1. 具前後台，後台為管理用途，前台則是給消費者使用
2. 後台以ASP.NET MVC架構撰寫
3. 前台則使用前後端分離的方式，後端使用ASP.NET Core來開發WebAPi服務，前端則使用Vue框架，前後端之間以AJAX技術呼叫
4. 以MS SQL作為資料庫，並使用EntityFramework存取，並創建Azure雲端資料庫以因應共同開發時的資料編輯需求
5. 以GitHub作為版控工具

### *以下為負責功能介紹
## 後台--訂單管理
1. 以三層式架構撰寫
2. 撰寫擴充方法進行ToVM和ToDTO的轉型
3. 在Controller以private存取修飾詞用於儲存Service取回的資料，保護數據的封裝性，讓外部的使用者不能直接訪問這些數據，且讓該物件在OrderController的建構子中被初始化
## 前台--
