# Unity Simple UI
平時Unity專案會使用到的一些遊戲系統UI範例實現。


## 介面工具
> 能夠以設置`UIOption`進行動態配置的物件。

### 動態生成介面模組
> 可被介面管理員`UIManager`直接動態生成的介面工具。

#### 介面管理員 UIManager

+ 說明
透過它管理及調用其他動態介面模組。

* 初始化
 1. 新增Canvas
於Hierarchy右鍵增添Canvas。

 2. 新增UIManager
`Menu -> GameObject -> SimpleUI -> UI Manager`

 3. 依照需求新增其他欲動態控制之UI模組。
`UIManager Component > Context Menu > Add 動態模組名稱`

#### 彈跳視窗 Dialog

+ 說明
彈跳視窗為整面提醒視窗，將打斷使用者流程的強制提示。
	+ 提醒視窗: 作為使用者動作確認或提示，最多為兩種選擇，通常為確認即取消，適合運用在系統提示、警告等。
	+ 選擇視窗: 為多選一，可客制化按鍵內容及操作。
	+ 資訊視窗: 適合運用於大量文字資訊，其內容將附有滾動條。例如:隱私權聲明視窗等。

* 初始化
`UIManager Component > Context Menu > Add Dialog Manager`

* 調用方式

* 範例資源位置
範例場景`SimpleUI > Scenes > DialogSample.unity`

* 目前支援類型
	- [x] 提醒
	- [x] 選擇
	- [x] 資訊



#### 提示介面 Toast
+ 說明
適用於簡單的提示通知，不影響使用者體驗為原則。
	+ 消逝吐司: 將於一段時間後自動消逝淡出。
	+ 一般吐司: 一般吐司提示，需自行刪除。

* 初始化
`UIManager Component > Context Menu > Add Toast Manager`

* 調用方式

* 目前支援類型
	- [x] 消逝
	- [x] 一般

#### 讀取介面 Loading
+ 說明
讀取視窗適用於異步情形。提示型將有讀取介面。

* 初始化

* 調用方式

* 目前支援類型
	- [ ] 透明
	- [ ] 提示
	- [ ] 讀取條
	- [ ] 環形讀取

### 非動態生成介面模組

#### 頁籤 Tabs
+ 說明
從多頁籤擇一後，更新所有頁籤之狀態，並觸發動作。

* 初始化
 1. 新增TabsGroup
`Menu -> GameObject -> SimpleUI -> Tabs`

 2. 於TabsGroup Component中點擊 `Create Tab` 加入頁籤。

* 範例資源位置
範例場景`SimpleUI > Scenes > TabsSample.unity`

* 目前支援類型
	- [x] 一般
	- [x] 垂直
	- [x] 水平


## 小元件 UIComponent
> 其他另行設計之預置物件。

### 輸入框
### 開關
### 標籤


## 效果
> 做為輔助UI的效果。

### 互動效果 InteractionEffects
> 使用者與UI介面互動時套用的效果。

* 目前支援類型
	- [ ] 縮放
	- [ ] 置換圖片

### 視覺效果 VisualEffects
> 可套用於介面圖形上的視覺效果。

+ 說明

* 範例資源位置
`Assets > Prefabs > VisualEffects`

* 目前支援類型
	- [x] 模糊 Blur
	- [ ] 波動


## 補充

### 使用版本
Unity 2019.4(LTS)
### 規格
程式執行時，UI將會隨著螢幕比例進行調整。
橫向支援 4:3 至 21:9 比例。(Canvas參考尺寸 1280 X 720)
直向支援 3:4 至 9:21 比例。(Canvas參考尺寸 720 X 1280)

