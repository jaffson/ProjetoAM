
var defaults = {

	// display
	defaultView: 'month',
	aspectRatio: 1.35,
	header: {
		left: 'title',
		center: '',
		right: 'today prev,next'
	},
	weekends: true,
	
	// editing
	//editable: false,
	//disableDragging: false,
	//disableResizing: false,
	
	allDayDefault: true,
	ignoreTimezone: true,
	
	// event ajax
	lazyFetching: true,
	startParam: 'start',
	endParam: 'end',
	
	// time formats
	/*titleFormat: {
		month: 'MMMM yyyy',
		week: "MMM d[ yyyy]{ '&#8212;'[ MMM] d yyyy}",
		day: 'dddd, MMM d, yyyy'
	},
	columnFormat: {
		month: 'ddd',
		week: 'ddd M/d',
		day: 'dddd M/d'
	},
	timeFormat: { // for event elements
		'': 'h(:mm)t' // default
	},*/
	titleFormat: {
	    month: 'MMMM yyyy',
	    week: "d [ yyyy]{ '&#8212;'[ MMM] d MMM yyyy}",
	    day: 'dddd, d MMM, yyyy'
	},
	columnFormat: {
	    month: 'ddd',
	    week: 'ddd d/M',
	    day: 'dddd d/M'
	},
	allDayText: 'dia todo',
	axisFormat: 'H:mm',
	timeFormat: {
	    '': 'H(:mm)',
	    agenda: 'H:mm{ - H:mm}'
	},
	
	// locale
	isRTL: false,
	firstDay: 0,
	/*monthNames: ['January','February','March','April','May','June','July','August','September','October','November','December'],
	monthNamesShort: ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'],
	dayNames: ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'],
	dayNamesShort: ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'],
	buttonText: {
		prev: '&nbsp;&#9668;&nbsp;',
		next: '&nbsp;&#9658;&nbsp;',
		prevYear: '&nbsp;&lt;&lt;&nbsp;',
		nextYear: '&nbsp;&gt;&gt;&nbsp;',
		today: 'today',
		month: 'month',
		week: 'week',
		day: 'day',
		resourceDay: 'resource'
	},*/
	monthNames: ['Janeiro', 'Fevereiro', 'Mar�o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
	monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
	dayNames: ['Domingo', 'Segunda', 'Ter�a', 'Quarta', 'Quinta', 'Sexta', 'S�bado'],
	dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'S�b'],
	buttonText: {
	    prev: '&nbsp;&#9668;&nbsp;',
	    next: '&nbsp;&#9658;&nbsp;',
	    prevYear: '&nbsp;&lt;&lt;&nbsp;',
	    nextYear: '&nbsp;&gt;&gt;&nbsp;',
	    today: 'hoje',
	    month: 'm�s',
	    week: 'semana',
	    day: 'dia',
        resourceDay: 'Profissional'
	},
	
	// jquery-ui theming
	theme: false,
	buttonIcons: {
		prev: 'circle-triangle-w',
		next: 'circle-triangle-e'
	},
	
	//selectable: false,
	unselectAuto: true,
	
	dropAccept: '*'
	
};

// right-to-left defaults
var rtlDefaults = {
	header: {
		left: 'next,prev today',
		center: '',
		right: 'title'
	},
	buttonText: {
		prev: '&nbsp;&#9658;&nbsp;',
		next: '&nbsp;&#9668;&nbsp;',
		prevYear: '&nbsp;&gt;&gt;&nbsp;',
		nextYear: '&nbsp;&lt;&lt;&nbsp;'
	},
	buttonIcons: {
		prev: 'circle-triangle-e',
		next: 'circle-triangle-w'
	}
};


