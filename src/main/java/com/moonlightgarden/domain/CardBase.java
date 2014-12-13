package com.moonlightgarden.domain;

import com.moonlightgarden.platform.OutputData;

public class CardBase extends OutputData {
  public String type;
  public String clazz;
  public int STR;
  public int AGI;
  public int CON;
  public int DEX;
  public int INT;
  public int SEN;
  public String armorUsable;
  public String weaponUsable;
  public String buff;
  public int buffLevel;
  
  public String getType() {
    return type;
  }
  public void setType(String type) {
    this.type = type;
  }
  public String getClazz() {
    return clazz;
  }
  public void setClazz(String clazz) {
    this.clazz = clazz;
  }
  public int getSTR() {
    return STR;
  }
  public void setSTR(int sTR) {
    STR = sTR;
  }
  public int getAGI() {
    return AGI;
  }
  public void setAGI(int aGI) {
    AGI = aGI;
  }
  public int getCON() {
    return CON;
  }
  public void setCON(int cON) {
    CON = cON;
  }
  public int getDEX() {
    return DEX;
  }
  public void setDEX(int dEX) {
    DEX = dEX;
  }
  public int getINT() {
    return INT;
  }
  public void setINT(int iNT) {
    INT = iNT;
  }
  public int getSEN() {
    return SEN;
  }
  public void setSEN(int sEN) {
    SEN = sEN;
  }
  public String getArmorUsable() {
    return armorUsable;
  }
  public void setArmorUsable(String armorUsable) {
    this.armorUsable = armorUsable;
  }
  public String getWeaponUsable() {
    return weaponUsable;
  }
  public void setWeaponUsable(String weaponUsable) {
    this.weaponUsable = weaponUsable;
  }
  public String getBuff() {
    return buff;
  }
  public void setBuff(String buff) {
    this.buff = buff;
  }
  public int getBuffLevel() {
    return buffLevel;
  }
  public void setBuffLevel(int buffLevel) {
    this.buffLevel = buffLevel;
  }
}
