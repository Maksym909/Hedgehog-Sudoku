// did you take this task from codeWars ?
//row 
function validRow(board, row, col, value) {
    // j column
    for (let j = 0; j < 8; j++) {
        if (j !== col) {
            if (board[row][j] === value) {
                return false;
            }
        }
    }

    return true;
}

//column 
function validColumn(board, row, col, value) {
    // j row
    for (let i = 0; i < 8; i++) {
        if (i !== row) {
            if (board[i][col] === value) {
                return false;
            }
        }
    }

    return true;
}

//The sub-boxes function.
function validBox(board, row, col, value) {
    const startRow = row - (row % 3), startCol = col - (col % 3);

    for (let i = startRow; i < startRow + 3; i++) {
        for (let j = startCol; j < startCol + 3; j++) {
            if (i !== row && j !== col) {
                if (board[i][j] === value) {
                    return false;
                }
            }
        }
    }

    return true;
}
function validSudoku(board) {
    for (let i = 0; i < 9; i++) {
        for (let j = 0; j < 9; j++) {
            const value = board[i][j];
            if (value !== '.') {
                if (!validRow(board, i, j, value) || !validColumn(board, i, j, value) | !validBox(board, i, j, value)) {
                    return false;
                }
            }
        }
    }
    return true;
};
console.log(validSudoku([
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 5, 3, 4, 8],
    [1, 9, 8, 3, 4, 2, 5, 6, 7],
    [8, 5, 9, 7, 6, 1, 4, 2, 3],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 6, 1, 5, 3, 7, 2, 8, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 4, 5, 2, 8, 6, 1, 7, 9]
]));
console.log(validSudoku([
    [5, 3, 4, 6, 7, 8, 9, 1, 2],
    [6, 7, 2, 1, 9, 0, 3, 4, 8],
    [1, 0, 0, 3, 4, 2, 5, 6, 0],
    [8, 5, 9, 7, 6, 1, 0, 2, 0],
    [4, 2, 6, 8, 5, 3, 7, 9, 1],
    [7, 1, 3, 9, 2, 4, 8, 5, 6],
    [9, 0, 1, 5, 3, 7, 2, 1, 4],
    [2, 8, 7, 4, 1, 9, 6, 3, 5],
    [3, 0, 0, 4, 8, 1, 1, 7, 9]
]));