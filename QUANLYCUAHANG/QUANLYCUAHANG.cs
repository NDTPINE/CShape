using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Reflection;
using System.IO;

namespace QUANLYCUAHANG
{
    class Program
    {
        static void Main(string[] args){
            bool check = true;
            string select = input();
            List<Items> itemData = new List<Items>();
            List<typeProducts> typeData = new List<typeProducts>();
            while (check){
                if (select[0] == '1'){ 
                    resolveitem(select, ref itemData);
                }
                else if (select[0] == '2') {
                    resolvetype(select, ref typeData);
                }
                Console.WriteLine("Do you continues? <Y\t/\tN>");
                string yesNo = Console.ReadLine();
                if (yesNo == "N") check = false;
                else{
                    select = input();
                }
            }
            Console.ReadLine();
        }
        public static string input(){
            Console.WriteLine("W\tE\tL\tC\tO\tM\tE");
            Console.WriteLine("Please select the function");
            bool check = true;
            int selectFuntion = 0;
            string select = "";
            while (check){   
                Console.WriteLine("1. Function of Items");// Chọn tùy chỉnh về mặt hàng
                Console.WriteLine("2. Function of Type of Items");//Chọn tùy chỉnh về loại hàng
                selectFuntion = Convert.ToInt32(Console.ReadLine());
                if (selectFuntion == 1 || selectFuntion == 2){
                    check = false;
                }
                else Console.WriteLine("You entered the wrong! Please select again");
            }
            select = string.Concat(select, selectFuntion.ToString());
            if (selectFuntion == 1){
                check = true;
                int selectItems = 0;
                while (check) // lặp chọn đúng chức năng
                {
                    Console.WriteLine("Please select the function: "); //Chọn chức năng
                    Console.WriteLine("1. Add the item");
                    Console.WriteLine("2. Remove the item");
                    Console.WriteLine("3. Edit the item");
                    Console.WriteLine("4. Search the item");
                    Console.WriteLine("5. Show the item");
                    selectItems = Convert.ToInt32(Console.ReadLine());
                    if (selectItems < 6 && selectItems > 0){
                        check = false;
                    }
                    else Console.WriteLine("You entered the wrong! Please select again");
                }
                select = string.Concat(select, selectItems.ToString());
            }
            else if (selectFuntion == 2){
                check = true;
                int selectTypeOfItems = 0;
                while (check){
                    Console.WriteLine("Please select: ");
                    Console.WriteLine("1. Add the type of item");
                    Console.WriteLine("2. Remove the type of item");
                    Console.WriteLine("3. Edit the type of item");
                    Console.WriteLine("4. Search the type of item");
                    Console.WriteLine("5. Show the item");
                    selectTypeOfItems = Convert.ToInt32(Console.ReadLine());
                    if (selectTypeOfItems < 6 && selectTypeOfItems > 0){
                        check = false;
                    }
                    else Console.WriteLine("Please select again");
                }
                select = string.Concat(select, selectTypeOfItems.ToString());
            }
            return select;
        }

        public static void resolveitem(string select, ref List<Items> ListItems){
                switch (select[1]){
                case '1':
                    Console.WriteLine("A\tD\tD\t");// Chức năng thêm mặt hàng
                    Items add = creatItems();
                    Items index3 = ListItems.Find(x => x.itemCode == add.itemCode);
                    if (ListItems.IndexOf(index3) == -1) //kiểm tra mã mặt hàng đã có hay chưa?
                    {
                        ListItems.Add(add);
                    }
                    else Console.WriteLine("Item code is exist");//mã mặt hàng không trùng nhau
                    break;
                case '2':
                    Console.WriteLine("R\tE\tM\tO\tV\tE");
                    Items items = new Items();
                    Console.WriteLine("Input the codeItem to remove list item"); //nhập vào mã hàng để xóa mặt hàng
                    items.itemCode = Convert.ToInt32(Console.ReadLine());
                    Items index = ListItems.Find(x => x.itemCode == items.itemCode);
                    ListItems.RemoveAt(ListItems.IndexOf(index));
                    break;
                case '3':
                    Console.WriteLine("E\tD\tI\tT");
                    Items items2 = new Items();
                    Console.WriteLine("Input the codeItem to edit list item");
                    items2.itemCode = Convert.ToInt32(Console.ReadLine());
                    Items index2 = ListItems.Find(x => x.itemCode == items2.itemCode);
                    ListItems.RemoveAt(ListItems.IndexOf(index2));
                    Console.WriteLine("Input the new infomation");
                    Items temp = creatItems();
                    ListItems.Add(temp);
                    break;
                case '4':
                    searchItems(ListItems);
                    break;
                case '5':
                    Console.WriteLine("S\tH\tO\tW");
                    showitem(ListItems);
                    break;
                } 
        }

        public static Items creatItems(){
            Items item = new Items();
            Console.WriteLine("Input the itemCode");//nhập mã mặt hàng
            int temp1 = Convert.ToInt32(Console.ReadLine());
            item.itemCode = temp1;
            Console.WriteLine("Input the nameItems");// nhập tên mặt hàng
            string temp2 = Console.ReadLine();
            item.nameItem = temp2;
            Console.WriteLine("Input the dataexpiryDate mm/dd/yyyy"); //nhập hạn sử dụng mặt hàng
            DateTime temp3 = Convert.ToDateTime(Console.ReadLine());
            item.dataexpiryDate = temp3;
            Console.WriteLine("Input the companyProduct"); //Công ty sản xuất
            string temp4 = Console.ReadLine();
            item.companyProduct = temp4;
            Console.WriteLine("Input the Year Of Product"); //Năm sản xuất
            temp1 = Convert.ToInt32(Console.ReadLine());
            item.yearOfProduction = temp1;
            Console.WriteLine("Input the typeOfProduct");// loại hàng
            typeProducts tempN = new typeProducts();
            tempN.typeProduct = Console.ReadLine();
            item.typeOfProduct = tempN.typeProduct;
            return item;
        }

        public static void searchItems(List<Items> listItems){
            //người dùng tự chọn tìm kiếm theo mã mặt hàng, tên, công ty,..
            Console.WriteLine("You can find the item by ...");
            Console.WriteLine("1.Code");
            Console.WriteLine("2.Name");
            Console.WriteLine("3.Dataexpiry");
            Console.WriteLine("4.Company");
            Console.WriteLine("5.YearOfProducts");
            Console.WriteLine("6.TypeOfProducts");
            int choose = Convert.ToInt32(Console.ReadLine());
            Items temp = new Items();
            if (choose < 7 && choose > 0){
                switch (choose){
                    //tìm kiếm theo mã mặt hàng
                    case 1:
                        Console.WriteLine("input the code");
                        temp.itemCode = Convert.ToInt32(Console.ReadLine());
                        List<Items> codeSearch = new List<Items>();
                        foreach (Items it in listItems)
                        {
                            if (it.itemCode == temp.itemCode) codeSearch.Add(it);
                        }
                        showitem(codeSearch);
                        break;
                    // tìm kiếm theo tên mặt hàng
                    case 2:
                        Console.WriteLine("input the Name");
                        temp.nameItem = Console.ReadLine();
                        List<Items> nameSearch = new List<Items>();
                        foreach (Items it in listItems)
                        {
                            if (it.nameItem == temp.nameItem) nameSearch.Add(it);
                        }
                        showitem(nameSearch);
                        break;
                    // tìm kiếm theo hạn sử dụng
                    case 3:
                        Console.WriteLine("input the Dataexpiry mm/dd/yyyy");
                        temp.dataexpiryDate = Convert.ToDateTime(Console.ReadLine());
                        List<Items> Dataexpiry = new List<Items>();
                        foreach (Items it in listItems){
                            if (it.dataexpiryDate == temp.dataexpiryDate) Dataexpiry.Add(it);
                        }
                        showitem(Dataexpiry);
                        break;
                    //tìm kiếm theo tên công ty sản xuất
                    case 4:
                        Console.WriteLine("input the Company");
                        temp.companyProduct = Console.ReadLine();
                        List<Items> CompanySearch = new List<Items>();
                        foreach (Items it in listItems){
                            if (it.companyProduct == temp.companyProduct) CompanySearch.Add(it);
                        }
                        showitem(CompanySearch);
                        break;
                    //tìm kiếm theo năm sản xuất
                    case 5:
                        Console.WriteLine("input the YearOfProducts");
                        temp.yearOfProduction = Convert.ToInt32(Console.ReadLine());
                        List<Items> yearSearch = new List<Items>();
                        foreach (Items it in listItems){
                            if (it.yearOfProduction == temp.yearOfProduction) yearSearch.Add(it);
                        }
                        showitem(yearSearch);
                        break;
                    //tìm kiếm theo loại hàng
                    case 6:
                        Console.WriteLine("input the TypeOfProducts");
                        temp.typeOfProduct = Console.ReadLine();
                        List<Items> typeSearch = new List<Items>();
                        foreach (Items it in listItems){
                            if (it.typeOfProduct == temp.typeOfProduct) typeSearch.Add(it);
                        }
                        showitem(typeSearch);
                        break;
                }
            }
            else searchItems(listItems);//chọn sai thì chọn lại
        }

        public static void showitem (List<Items> items){
            Console.WriteLine("\tI\t T\t E\t M\t S");
            Console.WriteLine("{0,-14}{1,-20}{2,-20}{3,-20}{4,-20}{5,-14}", "Code", "Name", "Dataexpiry", "Company", "Year Of Products", "TypeOfProduct");
            foreach (Items temp in items){
                Console.WriteLine("{0,-14}{1,-20}{2,-20:d}{3,-20}{4,-20}{5,-14}", temp.itemCode, temp.nameItem, temp.dataexpiryDate,temp.companyProduct,temp.yearOfProduction,temp.typeOfProduct);
            }
            Console.WriteLine("Do you wanna record? Y / N");
            char recordFileItem = Convert.ToChar(Console.ReadLine());
            if (recordFileItem == 'Y'){
                using (StreamWriter sw = new StreamWriter("Item.txt")){
                    foreach (Items s in items){
                        sw.Write(s.itemCode + " ");
                        sw.Write(s.nameItem + " ");
                        sw.Write("{0:d}" + " ",s.dataexpiryDate);
                        sw.Write(s.companyProduct + " ");
                        sw.Write(s.yearOfProduction + " ");
                        sw.Write(s.typeOfProduct);
                        sw.WriteLine();
                    }
                    sw.Flush();
                }
                Console.WriteLine("The file is saved which is  ITEM.txt");
            }
        }

        public static void resolvetype(string select, ref List<typeProducts> typeData) 
        {
            switch (select[1]){
                case '1':
                    Console.WriteLine("A\t\tD\t\tD\t\t");
                    typeProducts add = creatType();
                    typeProducts index3 = typeData.Find(x => x.code == add.code);
                    if (typeData.IndexOf(index3) == -1)
                    {
                        typeData.Add(add);
                    }
                    else Console.WriteLine("Item code is exist");
                    break;
                case '2':
                    Console.WriteLine("R\tE\tM\tO\tV\tE");
                    typeProducts types = new typeProducts();
                    Console.WriteLine("Input the codeItem to remove list item");
                    types.code = Convert.ToInt32(Console.ReadLine());
                    typeProducts index = typeData.Find(x => x.code == types.code);
                    typeData.RemoveAt(typeData.IndexOf(index));
                    break;
                case '3':
                    Console.WriteLine("E\tD\tI\tT");
                    typeProducts types2 = new typeProducts();
                    Console.WriteLine("Input the codeItem to edit list item");
                    types2.code = Convert.ToInt32(Console.ReadLine());
                    typeProducts index2 = typeData.Find(x => x.code  == types2.code);
                    typeData.RemoveAt(typeData.IndexOf(index2));
                    Console.WriteLine("Input the new infomation");
                    typeProducts temp = creatType();
                    typeData.Add(temp);
                    break;
                case '4':
                    searchType(typeData);
                    break;
                case '5':
                    Console.WriteLine("S\tH\tO\tW");
                    showtype(typeData);
                    break;
            }
        }

        public static typeProducts creatType(){
            typeProducts types = new typeProducts();
            Console.WriteLine("Input the Typpe of Code");
            int temp1 = Convert.ToInt32(Console.ReadLine());
            types.code = temp1;
            Console.WriteLine("Input the Type of Name");
            string temp2 = Console.ReadLine();
            types.typeProduct = temp2;
            return types;
        }

        public static void searchType(List<typeProducts> typeProduct){
            Console.WriteLine("Choose the ItemCode or nameItems or...");
            Console.WriteLine("1.Code");
            Console.WriteLine("2.Name");
            int choose = Convert.ToInt32(Console.ReadLine());
            typeProducts temp = new typeProducts();
            if (choose < 3 && choose > 0){
                switch (choose){
                    case 1:
                        Console.WriteLine("input the Type of Code ");
                        temp.code   = Convert.ToInt32(Console.ReadLine());
                        List<typeProducts> codeSearch = new List<typeProducts>();
                        foreach (typeProducts ty in typeProduct)
                        {
                            if (ty.code == temp.code) codeSearch.Add(ty);
                        }
                        showtype(codeSearch);
                        break;
                    case 2:
                        Console.WriteLine("input the Type of Name");
                        temp.typeProduct = Console.ReadLine();
                        List<typeProducts> nameSearch = new List<typeProducts>();
                        foreach (typeProducts ty in typeProduct)
                        {
                            if (ty.typeProduct == temp.typeProduct) nameSearch.Add(ty);
                        }
                        showtype(nameSearch);
                        break;
                }
            }
            else searchType(typeProduct);
        }

        public static void showtype(List<typeProducts> types){
            Console.WriteLine("\tT Y P E   O F   P R O D U C T S");
            Console.WriteLine("{0,-14}{1,-30}","Code","Name");
            foreach (typeProducts temp in types)
            {
                Console.WriteLine("{0,-14}{1,-30}", temp.code, temp.typeProduct);
            }
            Console.WriteLine("Do you wanna record? Y / N");
            char recordFileType = Convert.ToChar(Console.ReadLine());
            if (recordFileType == 'Y'){
                using (StreamWriter sw = new StreamWriter("TypeProduct.txt")){
                    foreach (typeProducts s in types){
                        sw.Write(s.code + " ");
                        sw.Write(s.typeProduct);
                        sw.WriteLine();
                    }
                    sw.Flush();
                }
                Console.WriteLine("The file is saved which is  TypeProduct.txt");
            }
        }
    }
    class Items
    {
        public int itemCode;
        public string nameItem;
        public DateTime dataexpiryDate;
        public string companyProduct;
        public int yearOfProduction;
        public string typeOfProduct;
    }

    class typeProducts
    {
        public int code;
        public string typeProduct;
    }
}
