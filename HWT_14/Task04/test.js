setInterval(function() {
  $("#refresh").load(location.href+" #refresh>*","");
}, 10000);