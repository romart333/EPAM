function Start() {
	if (!window.opener) { // поскольку открытую юзером вкладку нельзя закрыть, открываем со страницы index0 страницу index1
		window.open('index1.html');
		return;
	}
	
	var array = /index(\d)/g.exec(window.location.href);
	var pageNumber = array[1];
	var milliSeconds = 1000;
	var fullTime = 4000;
	var period = 5;
	var PAGECOUNT = 5;
	var periodInSeconds = period / milliSeconds;
	var remainingTime = fullTime / milliSeconds;
	var timerID;

	$('#play').on('click', function() {
		$(this).prop("disabled", true);
		$('#pause').prop("disabled", false);
		
		TimerTick();
	});

	$('#pause').on('click', function() {
		$(this).prop("disabled", true);
		$('#play').prop("disabled", false);
		
		clearInterval(timerID);
	});
	
	$('#back').on('click', function() {
		pageNumber--;
		OpenNewWindow();
	});

	function TimerTick() {
		timerID = setInterval(function() {
			$('#timer').text('Elapsed time: ' + remainingTime.toFixed(2));
			remainingTime -= periodInSeconds;
			if (remainingTime < 0) {
					pageNumber++;
					if (pageNumber === (PAGECOUNT + 1)) {
						var repeat = confirm('Repeat?');
						if (!repeat) {
							clearInterval(timerID);	
							window.close();
						}
						
						pageNumber = 1;			
					}
					
					OpenNewWindow();
			}
		}, periodInSeconds);
	};
	
	TimerTick();
		
	function OpenNewWindow() {
		clearInterval(timerID);
		window.location.href = 'index' + pageNumber + '.html';
		//window.open('index' + pageNumber + '.html');
	}
}

Start();