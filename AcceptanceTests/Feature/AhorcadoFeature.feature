Feature: AhorcadoFeature
	Testing Ahorcado Scenarios

@smoke
Scenario: Ganar el Ahorcado habiendo ingresado la palabra correcta
	Given Seteo testing como la palabra a adivinar
	When Ingreso la palabra 'testing'
	Then Deberia ver el mensaje de que gane

@smoke
Scenario: Perder el Ahorcado habiendo ingresado una palabra incorrecta
	Given Seteo testing como la palabra a adivinar
	When Ingreso la palabra 'probando'
	Then Deberia ver el mensaje de que perdi

@smoke
Scenario: Ganar el Ahorcado habiendo ingresado letras correctas
	Given Seteo testing como la palabra a adivinar
	When Ingreso letras 't,e,s,i,n,g'
	Then Deberia ver el mensaje de que gane

@smoke
Scenario: Perder el Ahorcado habiendo ingresado letras incorrectas
	Given Seteo testing como la palabra a adivinar
	When Ingreso letras 'p,r,o,b,a,d'
	Then Deberia ver el mensaje de que perdi