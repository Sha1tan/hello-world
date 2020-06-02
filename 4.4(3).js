/*function makeUser() {
  return {
    name: "Джон",
    ref: this
  };
};

let user = makeUser();

alert( user.ref.name );*/

//ref: this берёт текущее значение this функции makeUser

//------------------------------------

function makeUser() {
  return {
    name: "Джон",
    ref() {return this;}
  };
};

let user = makeUser();

alert( user.ref().name );

