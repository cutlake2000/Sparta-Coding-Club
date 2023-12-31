using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Message
    {
        Canvas canvas = new Canvas();

        int messageLeftPadding = 2; // 좌측 패딩

        // 타이틀 메시지 출력
        public void SetMessageInTitleScene()
        {
            int messageWidth = 31; // 메시지 가로 길이
            int startDrawingMessagePointX = (canvas.canvasWidth - messageWidth) / 2; // 메시지를 그리기 시작할 X 좌표
            int startDrawingMessagePointY = canvas.canvasHeight - 4; // 메시지를 그리기 시작할 X 좌표

            Console.SetCursorPosition(startDrawingMessagePointX, startDrawingMessagePointY);
            Console.Write("<< Press any button to start >>");
        }

        // 첫 화면 메시지 출력
        public void SetMessageInFirstStage()
        {
            string firstStageSelectMessage =
                "1. 캐릭터        2. 인벤토리        3. 상점        4. 던전 입장        5. 휴식";
            Console.SetCursorPosition(messageLeftPadding + 2, canvas.messagePanelHeight + 2);
            Console.Write("스파르타 마을에 오신 여러분 환영합니다.");
            Console.SetCursorPosition(messageLeftPadding + 2, canvas.messagePanelHeight + 3);
            Console.Write("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");

            Console.SetCursorPosition(
                (79 - firstStageSelectMessage.Length) / 2 + 1,
                canvas.messagePanelHeight + 5
            );
            Console.Write(firstStageSelectMessage);
        }

        // 플레이어 상태창 메시지 출력
        public void SetMessageInPlayerStatusPanel()
        {
            string playerStatusPanelSelectMessage = "1. 인벤토리        0. 나가기";
            Console.SetCursorPosition(
                (57 - playerStatusPanelSelectMessage.Length) / 2 + 34,
                canvas.canvasHeight - 3
            );
            Console.Write(playerStatusPanelSelectMessage);
        }

        // 인벤토리창 메시지 출력
        public void SetMessageInInventoryPanel()
        {
            string inventoryPanelSelectMessage = "1. 아이템 장착        2. 정렬하기        0. 나가기";

            Console.SetCursorPosition(
                (57 - inventoryPanelSelectMessage.Length) / 2 + 32,
                canvas.canvasHeight - 3
            );
            Console.Write(inventoryPanelSelectMessage);
        }

        // 인벤토리 정렬 창 메시지 출력
        public void SetMessageInInventorySortPanel()
        {
            string inventoryPanelSelectMessage = "1. 이름    2. 장착여부    3. 공격력    4. 방어력    0. 나가기";

            Console.SetCursorPosition(
                (57 - inventoryPanelSelectMessage.Length) / 2 + 31,
                canvas.canvasHeight - 3
            );
            Console.Write(inventoryPanelSelectMessage);
        }

        // 던전 난이도 메시지 출력
        public void SetDungeonInfoInDungeonPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 5);
            Console.Write("장착 / 장착 해제할 장비의 번호를 입력해주세요.");
        }

        // 장비 장착창 메시지 출력
        public void SetMessageInEquipWeaponPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 5);
            Console.Write("장착 / 장착 해제할 장비의 번호를 입력해주세요.");
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("0. 장비 장착 종료");
        }

        // 장비 장착창에서 잘못된 인덱스를 참고할 때 경고 메시지 출력
        public void SetErrorMessageInEquipWeaponPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 4);
            Console.Write("잘못된 넘버입니다, 다시 시도해주세요.         ");
        }

        // 상점 창 메시지 출력
        public void SetMessageInShopPanel()
        {
            Console.SetCursorPosition(43, canvas.canvasHeight - 4);
            Console.Write("1. 구매하기        2. 판매하기        0. 나가기");
        }

        // 상점 창 구매 메시지 출력
        public void SetBuyMessageInShopPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 5);
            Console.Write("구매할 장비의 번호를 입력해주세요.");
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("0. 상점 나가기");
        }

        // 상점 창 판매 메시지 출력
        public void SetSellMessageInShopPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 5);
            Console.Write("판매할 장비의 번호를 입력해주세요.");
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("0. 상점으로 돌아가기");
        }

        // 상점 창에서 보유 금액 출력
        public void SetGoldInShopPanel(Player player)
        {
            string money = "[ 보유 골드 | " + player.gold + " ]";
            Console.SetCursorPosition(93 - money.Length, canvas.canvasHeight - 3);
            Console.Write(money);
        }

        // 이미 구매한 상품일 때 경고 메시지 출력
        public void SetErrorMessageInShopPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("이미 구매한 상품입니다.                      ");
        }

        // 금액이 부족할 때 경고 메시지 출력
        public void SetErrorMessageLowMoneyInShopPanel()
        {
            Console.SetCursorPosition(35, canvas.canvasHeight - 3);
            Console.Write("금액이 부족합니다.           ");
        }
    }
}
