# csharp_api
ตัวอย่าง RESTFul API นี้พัฒนาด้วยภาษา C#.NET
โดยใช้ Web API Framework และ entity Framework
ดูรายละเอียดได้ที่ https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/

# การติดตั้งฐานข้อมูล
1. สร้างฐานข้อมูลชื่อ "SaleDB" หรือชื่ออื่นตามต้องการ ด้วย MSSQL Server Management Studio หรือเครื่องมืออื่นที่สะดวก
2. เปิดไฟล์ API\App_Data\saledb.sql ด้วย MSSQL Server Management Studio
3. ในบรรทัดแรกให้ทำการแก้ไขชื่อฐานข้อมูลให้ตรงกับชื่อที่ต้องการใช้งาน โดยค่า Default คือ "USE [SaleDB]"
4. คลิกปุ่ม "Execute" เพื่อทำการสร้างตารางข้อมูลและ Insert ข้อมูลเข้าฐานข้อมูล


# การติดตั้ง API
1. เปิด Solution จากไฟล์ csharp_api.sln ด้วย Visual Studio.NET version 2017 หรือสูงกว่า 
2. ที่ไฟล์ Web.config ทำการแก้ไข datasource (ชื่อเครื่องฐานข้อมูลหรือชื่อ Instance ของฐานข้อมูล), username, password, และ catalog (ชื่อฐานข้อมูล) 
   ตัวอย่างการ Config ฐานข้อมูลในไฟล์ Web.config
            data source=localhost;
            initial catalog=saledb;
            user id=sa;
            password=sa
3. ทำการ Publish API project ไปยัง Server (ชื่อเว็บไซต์ หรือหมายเลข IP) ที่ต้องการ

# การเข้าใช้งาน 
1. ใช้ GET method เพื่อดูรายการข้อมูล (พนักงาน) ทั้งหมด
   เช่น http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/employee
2. ใช้ GET method เพื่อดูรายละเอียดข้อมูล (พนักงาน) โดยการระบุรหัสต่อท้าย 
   เช่น  http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/employee/1
3. ใช้ POST method เพื่อเพิ่มข้อมูล
    เช่น http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/employee
4. ใช้ PUT method เพื่อปรับปรุงข้อมูล
    เช่น http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/employee/1  
5. ใช้ DELETE method เพื่อลบข้อมูล
    เช่น http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/employee/1
6. ใช้ POST method เพื่อ Login
    เช่น http://[ชื่อเว็บไซต์ หรือหมายเลข IP Server]/api/user

# การสร้าง API
1. สร้างตารางข้อมูลในฐานข้อมูล เช่น ตารางสินค้า (product)
2. สร้าง Controller class 
   - ในโฟลเดอร์ Controllers ให้ทำการ copy ไฟล์ EmployeeController.cs
     ไปเก็บไว้เป็นไฟล์ ProductController.cs
   - แก้ไขชื่อ Class, ชื่อตารางข้อมูล, และชื่อ Field ข้อมูล
 
3. สร้าง Model class
   - ในโฟลเดอร์ Models ให้ Double click ที่ไฟล์ *.edmx จะแสดงหน้าDiagram ของ Model class ขึ้นมา
   - ที่หน้า Diagram ทำการ Right mouse click แล้วเลือก “Update model from database”  
   - ที่ Tab “Add” ให้คลิกเลือกตารางสินค้า VS.NET จะทำการสร้าง Product.cs ให้อัตโนมัติ 

