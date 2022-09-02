//#include<ESP32Servo.h>
int _pinRemort50 = 25;
int _pinPushUp = 26;
int _pinPushDown = 27;
int _pinStart = 14;

char _level ;//Unityから送られてくる命令

//Servo _myServoUp;
//Servo _myServoDown;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  
  pinMode(_pinRemort50, OUTPUT);
  pinMode(_pinPushUp, OUTPUT);
  pinMode(_pinPushDown, OUTPUT);
  pinMode(_pinStart, OUTPUT);
  
  /*_myServoUp.attach(_pinPushUp);
  _myServoDown.attach(_pinPushDown);

  _myServoUp.write(30);
  _myServoDown.write(30);*/

  Serial.println("connected");
}


void loop() {
  // put your main code here, to run repeatedly:
  if( Serial.available() ) {
    _level = Serial.read();

    switch(_level)
    {
      case 'u':
        //Up
        PushUp();
        Serial.println("+");
        break;

      case 'd':
        //Down
        PushDown();
        Serial.println("-");
        break;
        
      case 'm':
        //ShakeMax
        ShakeMax();
        Serial.println("m");
        break;

      case 's':
        //Start
        PushStart();
        Serial.println("s");
        break;
    }
    /*
    String lst = Serial.read();
    int _level = lst.toInt();

    if (_level > 0) {
      if (_level >= 60) {
        ShakeMax();
      }
      else {
        PushUp(_level);
      }
    }
    else if (_level < 0) {
      _level = -_level;
      PushDown(_level);
    }*/
  }
}
/*
void loop() {
  // put your main code here, to run repeatedly:
  ShakeMax();
  delay(100);
  PushDown(30);
  delay(100);
  PushUp();
}*/

void PushStart() {
  digitalWrite(_pinStart, HIGH);
  delay(100);
  digitalWrite(_pinStart, LOW);
  delay(100);
  Serial.println("start");
}

void ShakeMax() {
  Remort50();
  PushUp(10);
}

void Remort50() {
    digitalWrite(_pinRemort50, HIGH);
    delay(100);
    digitalWrite(_pinRemort50, LOW);
    delay(100);
  Serial.println("50");
}

void PushUp(int upCount) {
  for(int i=0; i < upCount; i++){
    PushUp();
  }
}

void PushUp() {
  /*_myServoUp.write(0);
  delay(80);
  _myServoUp.write(30);
  delay(170);*/
  digitalWrite(_pinPushUp, HIGH);
  delay(100);
  digitalWrite(_pinPushUp, LOW);
  delay(100);
  Serial.println("+");
}

void PushDown(int downCount) {
  for(int i=0; i < downCount; i++){
    PushDown();
  }
}

void PushDown() {/*
  _myServoDown.write(0);
  delay(80);
  _myServoDown.write(30);
  delay(170);*/
  digitalWrite(_pinPushDown, HIGH);
  delay(100);
  digitalWrite(_pinPushDown, LOW);
  delay(100);
  Serial.println("-");
}
