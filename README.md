# Unity Simple UI
平時Unity專案會使用到的一些遊戲系統UI範例實現。

## 介面管理員 UIManager

+ 說明
透過它管理及調用其他動態介面模組。

* 初始化
 1. 新增Canvas
於Hierarchy右鍵增添Canvas。

 2. 新增UIManager
Menu > GameObject > UI Toolkit > UI Manager

 3. 依照需求新增其他UI模組。
UIManager Component > Context Menu > Add 模組名稱

## 介面工具 UIWidget
分為介面模組及小元件。介面模組可由介面管理員直接控制，而小元件通常為構成模組的獨立部件。

### 介面模組 UIModule
可被介面管理員直接呼叫使用。

#### 彈跳視窗 Dialog

+ 說明
彈跳視窗為整面提醒視窗，將打斷使用者流程的強制提示。
	+ 提醒視窗: 作為使用者動作確認或提示，最多為兩種選擇，通常為確認即取消，適合運用在系統提示、警告等。
	+ 選擇視窗: 為多選一，可客制化按鍵內容及操作。
	+ 資訊視窗: 適合運用於大量文字資訊，其內容將附有滾動條。例如:隱私權聲明視窗等。

* 初始化
UIManager Component > Context Menu > Add Dialog Manager

* 調用方式

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
UIManager Component > Context Menu > Add Toast Manager

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

### 小元件 UIComponent
構成模組所使用之獨立小元件。
#### 按鈕
#### 輸入框
#### 開關
#### 標籤

## 效果
做為輔助UI的效果。
### 互動效果 InteractionEffects
使用者與UI介面互動時套用的效果。
- [ ] 點擊效果
    - [ ] 縮放
    - [ ] 置換圖片

### 視覺效果 VisualEffects
套用於介面圖形上的視覺效果。
- [ ] 波動

## 補充

### 使用版本
Unity 2019.4(LTS)
### 規格
UI將會隨著螢幕比例進行調整。
橫向支援 4:3 至 21:9 比例。(Canvas參考尺寸 1280 X 720)
直向支援 3:4 至 9:21 比例。(Canvas參考尺寸 720 X 1280)

