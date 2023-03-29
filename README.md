# H'Style 精品服飾網站

**Keyword: ASP.NET MVC、ASP.NET Core、WebAPi、三層式架構(表現層、業務邏輯層、資料存取層)、Vue3 composition API、前後端分離**  
- 此為多人合作專案(6人)
- 專案理念: 針對中高端客群精品消費需求所設計，向消費者提供更全方位的服務，如個人專屬推薦、建立自媒體及客戶關係的管理等
1. 具前後台，後台為管理用途，前台則是給消費者使用
2. 後台以ASP.NET MVC架構撰寫
3. 前台則使用前後端分離的方式，後端使用ASP.NET Core來開發WebAPi服務，前端則使用Vue框架，前後端之間以AJAX技術呼叫
4. 以MS SQL作為資料庫，並使用EntityFramework存取，並創建Azure雲端資料庫以因應共同開發時的資料編輯需求
5. 以GitHub作為版控工具
6. 從資料庫中返回的資料為多筆時，以IEnumerable<T>泛型介面回傳，開發人員可以根據自己的需要選擇轉換成List<T>或Array等型別，可以減少記憶體佔用，並提高效能

### 以下為負責部分介紹
## 後台--訂單管理
1. 以三層式架構撰寫，並在Repository實作Interface(介面)，提高程式碼可讀性與可維護性
2. 撰寫擴充方法，進行ToVM和ToDTO的轉型
3. 在Controller以private存取修飾詞用於儲存Service取回的資料，保護數據的封裝性，讓外部的使用者不能直接訪問這些數據，以建構子注入（Constructor Injection）方式來初始化
4. 利用PagedList和AJAX技術製作分頁，並用MVC中SelectListItem繫結DropDownList，改變pageSize，以達成選取呈現幾筆資料的效果
5. 使用JQuery處理前端，提升使用者體驗，如：一選擇訂單狀態或每頁呈現幾筆的下拉式選單時數據隨即更新，並配合AJAX技術做出搜尋時的autocomplete(顯示前五筆資料配對到的資料)
  
  ![Recording 2023-03-29 at 15 57 29](https://user-images.githubusercontent.com/115922701/228466078-a87d9123-b0b6-437c-8661-8dd0959f8d74.gif)

6. 以JQuery實作一鍵出貨(自動填入訂單狀態及出貨時間)
* 訂單管理首頁設定僅訂單狀態為待出貨才能被全選checkbox選到，是利用checkbox的disabled屬性達成
* 訂單修改頁的一鍵出貨button判斷是否為待出貨狀態，若不是則以hide屬性作按鈕隱藏
7. 一頁式操作: 
* 變更訂單狀態可在訂單管理首頁操作，是以form自動繫結Controller動作方法的參數，在動作方法用for迴圈做逐一修改
* 訂單詳情利用Boostrap的Collapse點按後即可展示配送詳情及訂單商品詳情，並且可檢視、列印撿貨單，是以JavaScript的print實作列印功能
  
  ![Recording 2023-03-29 at 16 05 02 (1)](https://user-images.githubusercontent.com/115922701/228468108-b5251165-df70-4c35-ade2-7bbe575a480a.gif)

8. 若需由客服端取消訂單，則需要進入修改訂單頁方能操作，取消訂單以Boostrap的Modal實作，並可選擇是否寄信通知顧客訂單取消，以選取的取消訂單描述作為信件內容，再使用Google SMTP來實作後端寄信，取消訂單的原因也會顯示在訂單詳情中
  ![擷取](https://user-images.githubusercontent.com/115922701/228470749-d8d9ace4-7ea0-4065-830b-ea8106796df5.PNG)

9. 利用HttpContext.User 屬性`this.User.Identity.Name;`，取得已驗證的操作員工的帳號，並記錄在訂單操作(Log)
10. 訂單狀態的下拉式選單設計上，若更改為下一個狀態進程後就不能往回選擇，避免操作者誤改
### 資料表設計:
* 訂單取消不直接刪除資料庫中資料，而是以狀態欄位紀錄是否取消，好處是當需要對訂單進行帳務對帳時，可避免因為刪除資料而導致帳務錯誤，也可以查詢已取消的訂單
* 紀錄客戶取消訂單時間，以比對7天鑑賞期是否已過
* 訂單、訂單狀態、訂單狀態描述、訂單詳情及訂單操作分別都有各自的資料表，以實現第二正規化
* 訂單操作資料表不與其他表作關聯，以達確切紀錄的功用
#### ＊另負責後台主頁呈現和_Layout.cshtml套版
## 前台--
