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
        status1.Name = Console.ReadLine(); //status클래스에 있는 Name의 값을 내가 입력한 값으로 한다.

        Console.WriteLine();
        Console.WriteLine("직업을 선택하세요");
        Console.WriteLine("1.전사:    강한 힘과 체력 방어력을 가지고 있지만 처참한 마법 방어력을 가지고 있습니다.");
        Console.WriteLine("2.마법사:    강한 마법공격력과 마법저항력을 가지고 있지만 처참한 공격력과 방어력을 가지고 있습니다.");
        Select select1 = new Select(); 
        select1.JobSelect(status1); //직업선택
        Console.WriteLine();
        
        
        ItemList itemview1 = new ItemList(); 
        
        
        ItemDatabase database = new ItemDatabase();
        ItemDatabase.ItemList();
        
        select1.MoveSelect(status1,itemview1,select1,database);
        
        Console.WriteLine();
        
        






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



        public ItemDatabase(string Name, int Type, int Hp, int Str, int MagicAttack, int Amor, string Information, int Equip, int Possession) //생성자 매개변수를 넣어 아이템 스텟관리 함
        {
            itemname = Name; //이름
            itemtype = Type; //아이템타입(도감)
            itemhp = Hp; //체력
            itemstr = Str; //공격력
            itemmagicattack = MagicAttack; //마법공격력
            itemamor = Amor; //방어력
            iteminformation = Information; //정보
            itemequip = Equip; //착용여부
            possession = Possession; //보유여부
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

            while (true) //메인메뉴창
            {
                Console.WriteLine();
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 장비데이터");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 숫자로 입력해주세요.");
                Console.Write(">> ");
                string input = Console.ReadLine(); //행동입력
                int inputchange = int.Parse(input); //입력한 숫자를 정수로 변환
                if (inputchange == (int)select.status)  //입력한 값과 select라는 enum에 status 접근 그걸 인트값으로 바꾸고 비교
                {
                    
                    if (inputchange == 1) // 1 선택시 상태창 ?? 왜지?? 왜 조건을 하나 더 썻지? (버그없으니 넘어갈게요)
                    {
                        Console.Clear();
                        Console.WriteLine("상태보기를 선택하셨습니다.");
                        status1.StatusView1();  //스테이터스 관련 메서드 호출
                        status1.StatusView2(status1); //
                        status1.StatusView3(); //
                        status1.statusview4(status1); //
                        
                        Console.WriteLine("원하는 행동을 입력해주세요.");
                        Console.Write(">>");
                        Console.WriteLine("0. 나가기") ;
                        EndSelect(status1, itemview1, select1, data);
                        break;
                    }
                }
                else if (inputchange == (int)select.inventory) //인벤토리 들어가기 enum의 값을 2로 설정했기 때문에 2입력시 들어가져요
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
        public void EndSelect(Status status1, ItemList itemview1, Select select1,ItemDatabase data) //나가기 메서드
        {

            
           
                
                int input = int.Parse(Console.ReadLine());
                Console.Clear();
            if (input == 0) //0번 누르면 나가져요 하지만 이 메서드 때문에 작동 오류가 나서 거의 안씁니다... 작동순서가 망가져서..
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

                if (choice == (int)joblist.warrior) //마찬가지로 enum으로 작성
                {
                    Console.WriteLine("전사로 전직했습니다.");
                    status1.Job = "warrior";
                    status1.SetWarriorStats(); //직업 선택시 직업에 맞는 전사 기본 스테이터스 설정
                    break;
                }
                else if (choice == (int)joblist.magician) 
                {
                    Console.WriteLine("마법사로 전직했습니다");
                    status1.Job = "magician";
                    status1.SetmagicianStats(); //직업 선택시 직업에 맞는 마법사 기본 스테이터스 설정
                    break;
                }
                else if (choice == (int)joblist.magicswordsman) //히든직업도 만들었습니다.
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
                if (inputchange3 == 1) //1번 누르면 장착관리로 이동합니다. 장착한 아이템 보유 그리고 인벤토리 확인
                {
                    InventoryEquip(status1,itemview1,select1,itemlist); 
                    
                
                }
                
                
                else if (inputchange3  == 0) //0번 누르면 나가집니다. 월래 메서드로 자동화 시킬려고 했는데 버그가 생겨서 분리했습니다.
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
            foreach (ItemDatabase iteminventory1  in ItemDatabase.item) //아이템데이터베이스 속한 아이템이라는 이름의 리스트를 아이템인벤토리1이라는 이름에 넣은다.
            {
                if (iteminventory1.possession == 1) //인벤토리1안에 속한 possession의 값이 1일 때 possession이 1인 값만 보여줌
                {
                    string equipon = iteminventory1.itemname; //if문 안과 밖에서 사용하기 위해서 사용
                    if (iteminventory1.itemequip == 1) 
                    {
                        equipon = "E"; //착용 유무
                    }
                    
                    Console.WriteLine($"{number}.  {equipon} ,{iteminventory1.itemname}, {iteminventory1.itemstr}, {iteminventory1.itemamor}, {iteminventory1.itemhp}, {iteminventory1.itemmagicattack}, {iteminventory1.iteminformation}");
                    
                    number++;

                }

            }
            while(true)
            {
                int itemnumber = 1; //
                string input4 = Console.ReadLine();
                int inputchange4 = int.Parse(input4); 
                foreach (ItemDatabase itemposse in ItemDatabase.item)
                {


                    if (itemposse.possession == 1) //possession의 값이 1이었을 때
                    {
                        if (itemnumber == inputchange4) //입력한 값이 아이템넘버와 같을 때
                                                        //의문점!! 입력한 값은 자신이 원하는 값을 입력하겠지만
                                                        //아이템넘버는 지정하지 않아도 항상 내가 입력한 값과 같은 이유가 무엇일까?
                                                        //입력한 값이 1 이여도 아이템넘버는 지정하지 않는 이상 무작위 가능성도 있지않나요?
                        {
                            if (itemposse.itemequip == 1) //itemquip 값이 1이면
                            {
                                Console.WriteLine("장착해제"); //장착해제 출력
                                itemposse.itemequip = 0; //값이 0이된다. // 난 이런것도 생각못한 ...
                                break;
                            }
                            else if (itemposse.itemequip == 0) //0이된다면 
                            {
                                Console.WriteLine("장착");
                                itemposse.itemequip = 1;
                                break;
                            }
                           
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다"); //그외입력시 
                            }
                            Console.WriteLine("0. 나가기");
                            
                        }

                        
                    }
                    itemnumber++;
                }
                if (inputchange4 == 0) //0 입력시 나가집니다.
                {
                    Console.Clear();
                    MoveSelect(status1, itemview1, select1, itemlist);
                }

            }
            
        }

       
    }


    enum joblist //직업종류
    {
        warrior = 1, //직업선택을 숫자로 입력할 때 필요
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
  
    

    class ItemList //도감
    {
        public ItemDatabase item = new ItemDatabase(); 
        
        public void itemview(Status stats, ItemList itemview, Select select1, ItemDatabase itemlist)
        {
            item = itemlist;
           
            string input2 = Console.ReadLine();
            int inputchange2 = int.Parse(input2);
           
            foreach (ItemDatabase itemdata in ItemDatabase.item)  //아이템에 있는 클래스 안에 아이템데이터베이스 클래스 안에 아이템을 아이템데이타 변수에 넣는다
            {
                
                if (itemdata.itemtype == inputchange2) //아이템타입이 입력 값과 같으면 타입에 맞는 아이템 출력
                {
                    Console.WriteLine($"{itemdata.itemname}: {itemdata.iteminformation}"); //이름과 아이템정보 출력
                    
                    

                }
                
                
            }
            Console.WriteLine("0. 나가기");
            select1.EndSelect(stats ,itemview, select1, itemlist);
           
            
        }
       
       
      
    }
}

    


