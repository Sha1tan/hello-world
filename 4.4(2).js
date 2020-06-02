let obj, method;

obj = {
  go: function() { alert(this); }
};

obj.go();               

(obj.go)();             

(method = obj.go)();   

(obj.go || obj.stop)(); 

// В первых двух случаях происходит вызов метода объекта obj, this ссылается на него.

// В последних двуч теряется значение this