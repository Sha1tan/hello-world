let user = {
  name: "Джон",
  go: function() { alert(this.name) }
};

(user.go)()
//Не было точки с запятой после let user