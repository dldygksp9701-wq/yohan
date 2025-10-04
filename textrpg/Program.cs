using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Playview
{
    
    static void Main()
    {
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("너의 이름은 뭐야?");
        Status status1 = new Status();
        status1.Name = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("직업을 선택하세요");
        Console.WriteLine("1.전사:    강한 힘과 체력 방어력을 가지고 있지만 처참한 마법 방어력을 가지고 있습니다.");
        Console.WriteLine("2.마법사:    강한 마법공격력과 마법저항력을 가지고 있지만 처참한 공격력과 방어력을 가지고 있습니다.");
        Select select1 = new Select();
        select1.JobSelect(status1); //직업선택
        Console.WriteLine();
        
        
        ItemList itemview1 = new ItemList();
        
        Item itemlist = new Item();
        ItemDatabase database = new ItemDatabase();
        ItemDatabase.ItemList();
        
        select1.MoveSelect(status1,itemview1,select1,database);
        
        Console.WriteLine();
        
        






    }

    

    class Item
    {
        
        
        private string name;

        public string ItemName { get; set; }
        public int ItemType { get; set; }
        public int ItemEffect { get; set; }

        public enum type
        {
            weaphon = 1,
            armor = 2,
            potion = 3
        }


        
        public enum WeaponName
        {

            branch = 0,  //나뭇가지
            ironsword = 1, //철검
            pick = 2,  //곡괭이
            gunwithoutholes = 3, //구멍이 없는 총
            poisonknife = 4,  //독칼
            knife = 5 //칼
        }
        enum Armor
        {
            newspaper = 0, //신문지 갑옷
            Shabbyclothes = 1, //허름한옷
            clothes = 2, //평범한옷
            expensiveclothes = 3 //값비싼옷

        }
        enum Potion
        {
            strangepotion = 0, //이상한물약
            potion = 1,  //물약
            poisonpotion = 2 //독물약
        }

       

        
          

    }
    public class ItemDatabase
    {
        public ItemDatabase() { }
        public string itemname;
        public int itemtype;
        public int itemstr;
        public int itemmagicattack;
        public int itemamor;
        public string iteminformation;
        public int itemequip;
        public int itemhp;
        public int possession;



        public ItemDatabase(string Name, int Type, int Hp, int Str, int MagicAttack, int Amor, string Information, int Equip, int Possession)
        {
            itemname = Name;
            itemtype = Type;
            itemhp = Hp;
            itemstr = Str;
            itemmagicattack = MagicAttack;
            itemamor = Amor;
            iteminformation = Information;
            itemequip = Equip;
            possession = Possession;
        }
        public static List<ItemDatabase> item = new List<ItemDatabase>();

        public static void ItemList()
        {
            item.Add(new ItemDatabase("나뭇가지", 1, 0, 5, 5, 0, "공격력 5증가 마법공격력 5증가", 1,1));
            item.Add(new ItemDatabase("철검", 1, -20, 13, -6, 0, "체력 -20 감소 공격력 13 증가 마법공격력 -6 감소", 0,1));
            item.Add(new ItemDatabase("신문지", 2, 30, 0, 1, 3, "마법 공격력 1증가 방어력 3증가", 1,1));
            item.Add(new ItemDatabase("이상한물약", 3, -80, 27, 60, 30, "보기만해도 신기한 물약 빨리 써보고싶지만 능력은 모르겠다", 1,1));
            item.Add(new ItemDatabase("값비싼 옷", 2, 200, 3, 200, 400, "체력 200 공격력 3 마법공격력 200 방어력 400증가", 0, 0));
        }
    }
    
    class Select
    {
       
        public void MoveSelect(Status status1, ItemList itemview1, Select select1, ItemDatabase data)
        {

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 장비데이터");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 숫자로 입력해주세요.");
                Console.Write(">> ");
                string input = Console.ReadLine(); //이름 입력
                int inputchange = int.Parse(input);
                if (inputchange == (int)select.status)
                {
                    Console.WriteLine("상태보기를 선택하셨습니다.");
                    if (inputchange == 1)
                    {
                        Console.Clear();
                        status1.StatusView1();
                        status1.StatusView2(status1);
                        status1.StatusView3();
                        status1.statusview4(status1);
                        
                        Console.WriteLine("원하는 행동을 입력해주세요.");
                        Console.Write(">>");
                        Console.WriteLine("0. 나가기") ;
                        EndSelect(status1, itemview1, select1, data);
                        break;
                    }
                }
                else if (inputchange == (int)select.inventory)
                {
                    
                    Console.WriteLine("인벤토리를 선택하셨습니다.");
                    Console.Clear();
                    InventoryList(status1, itemview1, select1, data);
                    break ;
                    
                }
                else if(inputchange == (int)select.itemlist)  //아이템리스트이동
                {
                    Console.Clear ();
                    Console.WriteLine("아이템리스트를 선택했습니다");
                    Console.WriteLine("1. 무기 2.방어구 3. 물약");
                    Console.WriteLine();
                    Console.WriteLine();
                    
                    
                    itemview1.itemview(status1, itemview1,select1,data);
                    
                    break ;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
        public void EndSelect(Status status1, ItemList itemview1, Select select1,ItemDatabase data)
        {

            
           
                
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
            if (input == 0)
            {

                MoveSelect(status1, itemview1, select1, data);

            }
            else
            {
                Console.WriteLine("잘못 입력했습니다");
                EndSelect(status1, itemview1, select1, data);
            }
            
                

        }
        public void JobSelect(Status status1) //직업선택
        {
            while (true)
            {
                string job = Console.ReadLine();
                int choice = int.Parse(job);

                if (choice == (int)joblist.warrior)
                {
                    Console.WriteLine("전사로 전직했습니다.");
                    status1.Job = "warrior";
                    status1.SetWarriorStats();
                    break;
                }
                else if (choice == (int)joblist.magician)
                {
                    Console.WriteLine("마법사로 전직했습니다");
                    status1.Job = "magician";
                    status1.SetmagicianStats();
                    break;
                }
                else if (choice == (int)joblist.magicswordsman)
                {
                    Console.WriteLine("히든직업 마검사로 전직했습니다");
                    Console.WriteLine();
                    Console.WriteLine("마검사는 마법과 검사의 길을 완전히 깨우쳤을 때 전설로 불리우는 칭호입니다.");
                    Console.WriteLine("역사적으로도 마지막으로 불렸을 때는 약 300년 전 입니다.");
                    Console.WriteLine("기록에는 거의 남아나지 않지만 소문으로는 힘 방어 마법방어 마법공격이 우세하다는 이야기가 있습니다.");
                    status1.Job = "magicswordsman";
                    break;
                }
                else
                {
                    Console.WriteLine("잘못 선택하셨습니다.");
                }
            }
        }
        public void InventoryList(Status status1, ItemList itemview1, Select select1, ItemDatabase itemlist) //인벤토리
        {
            
            
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            
            while (true)
            {
                string input3 = Console.ReadLine();
                int inputchange3 = int.Parse(input3);
                if (inputchange3 == 1)
                {
                    InventoryEquip(status1,itemview1,select1,itemlist);
                    
                
                }
                
                
                else if (inputchange3  == 0)
                {

                    Console.Clear();
                    MoveSelect(status1, itemview1, select1, itemlist);

                }
                else
                {
                    Console.WriteLine("잘못 입력했습니다");
                    EndSelect(status1, itemview1, select1, itemlist);
                }

            }
            


        }
        public void InventoryEquip(Status status1, ItemList itemview1, Select select1, ItemDatabase  itemlist)
        {
            int number = 1;
            foreach (ItemDatabase iteminventory1  in ItemDatabase.item)
            {
                if (iteminventory1.possession == 1)
                {
                    string equipon = iteminventory1.itemname;
                    if (iteminventory1.itemequip == 1)
                    {
                        equipon = "E" + iteminventory1.itemname;
                    }
                    
                    Console.WriteLine($"{number}.  {equipon} ,{iteminventory1.itemname}, {iteminventory1.itemstr}, {iteminventory1.itemamor}, {iteminventory1.itemhp}, {iteminventory1.itemmagicattack}, {iteminventory1.iteminformation}");
                    
                    number++;

                }

            }
            while(true)
            {
                int itemnumber = 1;
                string input4 = Console.ReadLine();
                int inputchange4 = int.Parse(input4);
                foreach (ItemDatabase itemposse in ItemDatabase.item)
                {


                    if (itemposse.possession == 1)
                    {
                        if (itemnumber == inputchange4)
                        {
                            if (itemposse.itemequip == 1)
                            {
                                Console.WriteLine("장착해제");
                                itemposse.itemequip = 0;
                                break;
                            }
                            else if (itemposse.itemequip == 0)
                            {
                                Console.WriteLine("장착");
                                itemposse.itemequip = 1;
                                break;
                            }
                           
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다");
                            }
                            Console.WriteLine("0. 나가기");
                            
                        }

                        
                    }
                    itemnumber++;
                }
                if (inputchange4 == 0)
                {
                    Console.Clear();
                    MoveSelect(status1, itemview1, select1, itemlist);
                }

            }
            
        }

       
    }


    enum joblist //직업종류
    {
        warrior = 1,
        magician = 2,
        magicswordsman = 626626626
    }
    enum select //초반 선택
    {
        status = 1,
        inventory = 2,
        itemlist = 3
    }

    class Status //스테이터스정보
    {
        private string name;
        private int level;
        private string job;
        private int hp;
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public int Level { get; set; }

        public string Job
        {
            get { return job; }
            set
            {
                job = value;

            }
        }

        public int Hp { get; set; }

        public int Str { get; set; }
        public int Def { get; set; }
        public int Mdef { get; set; }
        public int money { get; set; }
        public int MagicAttack { get; set; }


        public void SetWarriorStats() //전사기본정보
        {


            Hp = 100;
            Str = 30;
            MagicAttack = 0;
            Def = 25;
            Mdef = 5;
            money = 100;
        }

        public void SetmagicianStats() //마법사기본정보
        {


            Hp = 60;
            Str = 8;
            MagicAttack = 21;
            Def = 13;
            Mdef = 26;
            money = 180;
        }


        public void StatusView1() //스테이터스출력 레벨
        {


            Level = 1;
            Console.Write($"level:  {Level}");
            Console.WriteLine();

        }
        public void StatusView2(Status player) //스테이터스출력 이름
        {
            Console.Write(player.Name);
            Console.WriteLine();
        }

        public void StatusView3() //스테이터스출력 스텟
        {



            Console.WriteLine($"체력: {Hp}");
            Console.WriteLine($"힘: {Str} + ");
            Console.WriteLine($"마법 공격력: {MagicAttack}");
            Console.WriteLine($"방어력: {Def}");
            Console.WriteLine($"마법방어력: {Mdef}");
            Console.WriteLine($"돈: {money}");
        }
        public void statusview4(Status playerjob) //직업 출력
        {
            Console.WriteLine($"직업:  {playerjob.job}");
        }

    }
  
    

    class ItemList
    {
        public ItemDatabase item = new ItemDatabase();
        
        public void itemview(Status stats, ItemList itemview, Select select1, ItemDatabase itemlist)
        {
            item = itemlist;
            //resetview();
            //Item.ItemDatabase.ItemList();
            string input2 = Console.ReadLine();
            int inputchange2 = int.Parse(input2);
           
            foreach (ItemDatabase itemdata in ItemDatabase.item)  //아이템에 있는 클래스 안에 아이템데이터베이스 클래스 안에 아이템을 아이템데이타 변수에 넣는다
            {
                
                if (itemdata.itemtype == inputchange2)
                {
                    Console.WriteLine($"{itemdata.itemname}: {itemdata.iteminformation}");
                    
                    

                }
                
                
            }
            Console.WriteLine("0. 나가기");
            select1.EndSelect(stats ,itemview, select1, itemlist);
           
            
        }
       
       
      
    }
}

    


