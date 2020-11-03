#include <Arduino.h> //é um recurso para referenciar a biblioteca Wiring
#include <Wire.h> //inclui a biblioteca Wire necessaria para comunicaçao i2c

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available())  //verifica se tem dados diponível para leitura
  {
    int byteRead = Serial.read(); //le bytwe mais recente no buffer da serial
    Serial.write(byteRead);   //reenvia para o computador o dado recebido
  }
}
