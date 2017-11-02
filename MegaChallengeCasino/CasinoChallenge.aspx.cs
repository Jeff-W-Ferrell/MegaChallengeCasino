using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class CasinoChallenge : System.Web.UI.Page
    {
        int playerMoney = 0; int bet = 0; int winnings;
        int firstImage = 0; int secondImage = 0; int thirdImage = 0;
        String[] images = new string[12] { "Bar.png", "Bell.png", "Cherry.png", "Clover.png", "Diamond.png", "HorseShoe.png", "Lemon.png", "Orange.png", "Plum.png", "Seven.png", "Strawberry.png", "Watermellon.png" };
        Random r = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            playerMoney = 100;
            playersMoneyLabel.Text = String.Format("{0:C}", playerMoney);
            randomThreeSymbols();
            if (!Page.IsPostBack)
                ViewState.Add("playerCash", playerMoney);
        }

        protected void pullLeverButton_Click(object sender, EventArgs e)
        {
            getBet();
            randomThreeSymbols();
            if (checkForBars())
                checkForWinnings();
            else youLose();
            noBetEntered();
        }

        private bool getBet()
        {
            doesYourBetExist();
            if (!int.TryParse(yourBetTextBox.Text.Trim(), out bet)) return false;
            return true;
        }

        private bool doesYourBetExist()
        {
            if (yourBetTextBox.Text.Length < 0) return false;
            return true;
        }

        private void randomThreeSymbols()
        {
            randomFirst();
            randomSecond();
            randomThird();
        }

        private int randomFirst()
        {
            firstImage = r.Next(0, 11);
            firstSlotMachineImage.ImageUrl = images[firstImage];
            return firstImage;
        }

        private int randomSecond()
        {
            secondImage = r.Next(0, 11);
            secondSlotMachineImage.ImageUrl = images[secondImage];
            return secondImage;
        }

        private int randomThird()
        {
            thirdImage = r.Next(0, 11);
            thirdSlotMachineImage.ImageUrl = images[thirdImage];
            return thirdImage;
        }

        private bool checkForBars()
        {
            if (firstImage == 0 || secondImage == 0 || thirdImage == 0) return false; 
            return true;
        }

        private void checkForWinnings()
        {
            cherries();
            sevens();
            if (winnings > 0) youWin();
            else youLose();
        }

        private int cherries()
        { 
            if (firstImage == 2 || secondImage == 2 || thirdImage == 2) winnings = bet * 2;
            if ((firstImage == 2 && secondImage == 2) || (firstImage == 2 && thirdImage == 2) 
                || (secondImage == 2 && thirdImage == 2))
                winnings = bet * 3;
            if (firstImage == 2 && secondImage == 2 && thirdImage == 2) winnings = bet * 4;
            return winnings;
        }

        private int sevens()
        {
            if (firstImage == 9 && secondImage == 9 && thirdImage == 9) winnings = bet * 100;
                return winnings;   
        }

        private void youLose()
        { 
            int playerMoney = (int)ViewState["playerCash"];
            playerMoney -= bet;
            playersMoneyLabel.Text = String.Format("{0:C}",playerMoney);
            ViewState.Add("playerCash", playerMoney);
            winnerLoserLabel.Text = String.Format("Sorry, you lost {0:C}.  Better luck next time.", bet);
        }

        private void youWin()
        {
            int playerMoney = (int)ViewState["playerCash"];
            playerMoney += winnings;
            playersMoneyLabel.Text = String.Format("{0:C}", playerMoney);
            ViewState.Add("playerCash", playerMoney);
            winnerLoserLabel.Text = String.Format("You bet {0:C} and won {1:C}", bet, winnings);
        }

        private void noBetEntered()
        {
            if (!getBet()) winnerLoserLabel.Text = "Place a bet and try your luck!";
        }
    }
}

     


