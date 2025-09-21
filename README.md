# シフト管理アプリ (ShiftManager)
学校のグループ活動で制作。  
従業員のシフト作業を効率化する業務支援アプリです。  

---

## 📌 プロジェクト概要
- カレンダー表示・コンボボックス選択で簡単にシフト登録  
- 年月選択で任意の期間のシフトを表示・編集可能  
- データは SQLite に保存  

---
## 構成管理

```
.
│
└─ Taguma
│ README.md アプリの仕様書
│ images/ アプリの機能ごとの説明画像
│
├─ 01_LogIn　　ログインクラス
│ ├─ Form1.Designer.cs 　画面デザイン
│ ├─ Form1.cs 　ログインのメインクラス
│ ├─ Form1.resx 　リソースファイル
│ └─ Form1.adminDB.cs 　adminデータベースとのパスワード適合処理クラス(外部クラス)
├─ 02_Dashboard　　ダッシュボードクラス
│ ├─ Dasyu.Designer.cs 　画面デザイン
│ ├─ Dasyu.cs 　ダッシュボードのメインクラス
│ └─ Dasyu.resx 　リソースファイル
├─ 03_ShiftSchedule　シフト表作成クラス
│ ├─01_ShiftScheduleMain
│ │ ├─01_ShiftScheduleDB 
│ │ │ ├─ShiftDB.cs 　shiftDataへのデータ挿入、更新、削除(外部クラス)
│ │ │ └─StaffDB.cs 　staffから従業員の取得をしシフト表に反映いしている(外部クラス)
│ │ ├─ShiftTableBuilder.cs 　シフト表の作成クラス(外部クラス)
│ │ ├─Shifts.Designer.cs　　フォームデザイン
│ │ ├─Shifts.cs 　シフト表のメインクラス
│ │ └─Shifts.resx　　リソースファイル
│ ├─02_StaffRegistration
│ │ ├─StaffRegistration.Designer.cs　　スタッフ登録のメインクラス
│ │ ├─StaffRegistration.cs 　フォームデザイン
│ │ ├─StaffRegistration.resx　　リソースファイル
│ │ └─StaffRegistrationDB.cs　　staffへのデータ追加(外部クラス)
│ ├─03_ShiftHpoe　　別アプリのため実装してないこの画面に従業員からのシフト希望が表示される
│ │ ├─ShiftHope.Designer.cs　　フォームデザイン
│ │ ├─ShiftHope.cs　　シフト希望のメインクラス
│ │ └─ShiftHope.resx 　リソースファイル
│ ├─ 04_Work　勤怠管理確認クラス
│ ├─ Work.Designer.cs 　画面デザイン
│ ├─ Work.cs 　勤怠管理のメインクラス
│ ├─ Work.resx 　リソースファイル
│ ├─ WorkItem.cs 　指定した日の従業員が働く時間が見れる(外部クラス)
│ └─ WorkItemDB.cs 　shiftDataから選択した日付のシフトデータを取得する処理(外部クラス)
│ ├─ ComonClass　共通の処理を格納したクラス
│ ├─ Comboltemcs.cs 　年、月、日の処理をコンボボックスに与える処理(外部クラス)
│ └─ DBHelper.cs 　データベースに接続するコードを保持しているクラス(外部クラス)
```
---

## データベース
```
CREATE TABLE staff (
   staff_id INT IDENTITY(1,1) PRIMARY KEY, --従業員ID
   staff_name VARCHAR(255) NOT NULL,--従業員名
   tell VARCHAR(20) NOT NULL,--従業員電話番号
   e_mail VARCHAR(255) NOT NULL,--従業員メールアドレス
   bank_account VARCHAR(50) NOT NULL,--従業員の銀行口座番号
   address VARCHAR(255) NOT NULL,--従業員の住所
   how VARCHAR(255) NOT NULL--従業員の通勤手段 コンボボックスから選択する
);
CREATE TABLE shiftData (
  shift_id INT IDENTITY(1,1) PRIMARY KEY,--シフトID
  staff_id INT NOT NULL,--従業員ID
　shift_day INT NOT NULL,--シフト登録日
　shift_month INT NOT NULL,--シフト登録月
  shift_year INT NOT NULL,--シフト登録年
  shift_type CHAR(1) NULL,  -- A, B, C などの勤務時間区分
  CONSTRAINT fk_shift_staff FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);
CREATE TABLE admin (
  admin_id INT IDENTITY(1,1) PRIMARY KEY,--管理者ID
  admin_password PRIMARY KEY,--ログインパスワード
  staff_id INT NOT NULL,--従業員ID
　created_at datetime NOT NULL--ログイン履歴
  CONSTRAINT fk_shift_staff FOREIGN KEY (staff_id) REFERENCES staff(staff_id)
);
```
---
## 🚀 実行方法
1. GitHubから `Taguma.exe` をダウンロード![Taguma.exe]( Taguma.exe) できないかもしれない
2. Windows 10/11 環境でダブルクリックして起動  
3. ID: 2, パスワード: ss  
4. 年・月を選択してシフトを管理  

※ ソースコードからビルドしたい場合は Visual Studio でプロジェクトを開き、ビルドしてください。

---

## 📷 画面イメージ
画像を直接見ることができないので画像ファイルから見てください
![画像ファイルのパス](images)
![ログイン画面](images/スクリーンショット-2025-09-20-145501.png)
![ダッシュボード](images/スクリーンショット-2025-09-20-145511.png)  
![シフト表作成](images/スクリーンショット-2025-09-20-145620.png)  
![勤怠確認](images/スクリーンショット-2025-09-20-145643.png)  
![流れ図](images/スクリーンショット-2025-09-20-145517.png)

---

## 🛠 技術スタック
- C# (.NET Framework / Windows Forms)  
- SQLite  
- Visual Studio 2022

---

## 👤 開発者
- 藤本翔平：作業プログラムコーディング、データベース実装  
- 他2名：プログラム・デザイン協力















