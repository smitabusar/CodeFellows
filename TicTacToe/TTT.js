//board has 9 elements starting from 0 to match the cells in 3*3 board. board is used to store the value 1 for Player 1 and 2 for Player 2. 
var board = new Array(0, 0, 0, 0, 0, 0, 0, 0, 0);
//Used to store number of user moves
var totalMoves = 0;
//Used to store the game wins & ties in a given series.
var gamesUser1Won = 0;
var gamesUser2Won = 0;
var gameDrawn = 0;

/*
fires user move, populates the cell & calls nextgame if a
victory or draw state has been reached.
*/
function userMove(element, form) {
    var currentPlayer = document.forms[0].txtCurPlayer.value;
    if (isCellEmpty(element.name)) {
        populateMove(element, currentPlayer);
        document.forms[0].txtCurPlayer.value = nextPlayer(currentPlayer);
        totalMoves += 1;
        if (totalMoves > 4) {
            var winner = whoHasWon();
            var ask = "N";
            if (winner == 1) {
                gamesUser1Won++;
                ask = currentPlayer + " you Win !!!\nDo you want to play again?";
            } else if (winner == 2) {
                gamesUser2Won++;
                ask = currentPlayer + " you Win !!!\nDo you want to play again?";
            } else if (totalMoves == 9 && winner == 0) {
                gameDrawn++;
                ask = "Its a draw !!!\nDo you want to play again?";
            }
            nextGame(ask, currentPlayer);

        }
    }

}

//checks if cell is empty.
function isCellEmpty(buttonID) {
    return (board[buttonID] == "0") ? true : false;
}

//Populates the array & the image
function populateMove(element, player) {
    if (player == "Player 1") {
        board[element.name] = 1;
        element.className = "button_x";
    } else {
        board[element.name] = 2;
        element.className = "button_o";
    }
}

//Fetches the next player for current game
function nextPlayer(player) {
    return (player == "Player 1") ? "Player 2" : "Player 1";

}

//Returns 1 if Player 1 wins, 2 if Player 2 wins and 0 if no one wins.
function whoHasWon() {
    //diagonal win
    if ((board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]))
        return board[4];

    //columns win
    for (var i = 0; i < 3; i++) {
        if (board[i] != 0 && board[i] == board[i + 3] && board[i] == board[i + 6])
            return board[i];
    }

    //row win
    for (var i = 0; i < 7; i += 3) {
        if (board[i] != 0 && board[i] == board[i + 1] && board[i + 1] == board[i + 2])
            return board[i];
    }
    
    //no win
    return 0;
}

//starts the nextGame. If user says cancel it starts the next series.
function nextGame(ask, currentPlayer) {
    if (ask != "N") {
        if (!confirm(ask)) {
            var msg = "Last Series was ";
            if (gamesUser1Won > gamesUser2Won)
                msg += "won by Player1 " + gamesUser1Won + ":" + gamesUser2Won + "!!";
            else if (gamesUser1Won < gamesUser2Won)
                msg += "won by Player2 " + gamesUser1Won + ":" + gamesUser2Won + "!!";
            else if (gamesUser1Won == gamesUser2Won)
                msg += "a Tie !!!";
            document.getElementById('spanDebug').innerText = msg;
            gamesUser1Won = 0;
            gamesUser2Won = 0;
            gameDrawn = 0;
            document.forms[0].txtCurPlayer.value = "Player 1";
        } else {
            document.forms[0].txtCurPlayer.value = currentPlayer;
        }
        newGame();
    }

}

function newGame() {
    for (i = 0; i < 9; i++) {
        board[i] = "0";
        document.forms[0][i + 1].className = "button_org";
    }
    totalMoves = 0;
    document.forms[0].txtGameDraw.value = gameDrawn;
    document.forms[0].txtGameP1.value = gamesUser1Won;
    document.forms[0].txtGameP2.value = gamesUser2Won;
}
