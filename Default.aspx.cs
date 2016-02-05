using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static private bool p1turn = true; //keeps track of whos turn it is 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblWinner.Text = "Welcome to CHOMP!  Player 1 is first."; 
            //welcome message for first time 
        }

    }

    protected void btn_Click(object sender, EventArgs e)
    {
        p1turn = !p1turn;//change turns
        if (p1turn)
            lblWinner.Text = "Player 1 turn";
        else
            lblWinner.Text = "Player 2 turn";

        //get the positon of the clicked button
        Button btn = (Button) sender;
        int clicked_row = int.Parse(btn.ID.Substring(3, 1));
        int clicked_col = int.Parse(btn.ID.Substring(4, 1));

        for(int i = clicked_col; i < 8; i++) //loop thru colums
        {
            for(int j = clicked_row; j > 0; j--) //loop thru rows 
            {
                //find button
                string ID = "btn" + j.ToString() + i.ToString();
                Button nextBtn = (Button)FindControl(ID); 
                //and change the color to white
                nextBtn.BackColor = System.Drawing.Color.White;
                nextBtn.BorderColor = System.Drawing.Color.White;
                nextBtn.ForeColor = System.Drawing.Color.White;
                //hide border
                nextBtn.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
                //disable button
                nextBtn.Enabled = false;

                //check for winners
                if(!btn62.Enabled && !btn51.Enabled && p1turn) 
                {
                    lblWinner.Text = "Game OVER!!!! Player 2 WINSSS!!!!";
                }
                else if (!btn62.Enabled && !btn51.Enabled && !p1turn)
                {
                    lblWinner.Text = "Game OVER!!!! Player 1 WINSSS!!!!";

                }

            }
        }



        

    }



    //function for new game button call
    protected void btnNewGame_Click(object sender, EventArgs e)
    {
        string ID = "";
        p1turn = true; //reset player1 game 
        lblWinner.Text = "Again?   Player 1 turn"; //change text 

        for (int i = 1; i < 8; i++) //loop thru columns
        {
            for(int j = 1; j < 7; j++) //loop thru rows 
            {
                ID = "btn" + j.ToString() + i.ToString();
                Button next_button = (Button)FindControl(ID); //find button
                next_button.BackColor = System.Drawing.Color.Blue;//change color back
                next_button.BorderColor = System.Drawing.Color.Blue;
                next_button.ForeColor = System.Drawing.Color.Blue;
                next_button.BorderStyle = System.Web.UI.WebControls.BorderStyle.Ridge;
                next_button.Enabled = true; //change ridges and make clickable
            }
        }

        //make the red button again
        btn61.Enabled = false;
        btn61.BorderColor = System.Drawing.Color.Red;
        btn61.BackColor = System.Drawing.Color.Red;
        btn61.ForeColor = System.Drawing.Color.Red;

    }
}