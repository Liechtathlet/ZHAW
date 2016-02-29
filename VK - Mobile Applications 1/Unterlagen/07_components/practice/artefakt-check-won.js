	/**
			This is an inefficient method of finding if a user has won.
		*/
		checkWon : function() {

			var in1;
			var in2;
			var x,y,i,j;

			for (x=0;x < this.COLUMNS;x++) {
		
				in1 = 0;
				in2 = 0;

				for (y=0;y < this.ROWS;y++) {
					if (this.cellStates[x][y] == 1) {
						if (++in1 == 4)
							return true;

						in2 = 0;
					}
					else if (this.cellStates[x][y] == 2) { 
						if (++in2 == 4)
							return true;

						in1 = 0;
					}
				}
			}


			for (y=0;y < this.ROWS;y++) {

				in1 = 0;
				in2 = 0;
	
				for (x=0;x < this.COLUMNS;x++) {
					if (this.cellStates[x][y] == 1) {
						if (++in1 == 4)
							return true;
						in2 = 0;
					}
					else if (this.cellStates[x][y] == 2) { 
						if (++in2 == 4)
							return true;

						in1 = 0;
					}
				}
			}	

			for (i=-this.COLUMNS;i < this.COLUMNS-3;i++) {
		
				in1 = 0;
				in2 = 0;
			
				for (j=0;j < this.ROWS;j++) {
					x = i + j;
					y = j;
					if (x >= 0 && y >= 0 &&  x < this.COLUMNS && y < this.ROWS) {
						if (this.cellStates[x][y] == 1) {
							if (++in1 == 4)
								return true;
							in2 = 0;
						}
						else if (this.cellStates[x][y] == 2) { 
							if (++in2 == 4)
								return true;

							in1 = 0;
						}
					}
				}
			}	

			
			for (i=-this.COLUMNS;i < this.COLUMNS-3;i++) {
		
				in1 = 0;
				in2 = 0;
			
				for (j=0;j < this.ROWS;j++) {
					x = i - j;
					y = j;
					if (x >= 0 && y >= 0 &&  x < this.COLUMNS && y < this.ROWS) {
						if (this.cellStates[x][y] == 1) {
							if (++in1 == 4)
								return true;
							in2 = 0;
						}
						else if (this.cellStates[x][y] == 2) { 
							if (++in2 == 4)
								return true;

							in1 = 0;
						}
					}
				}
			}	
		}
