package com.moonlightgarden.domain;

import com.moonlightgarden.platform.OutputData;

public class Profile extends OutputData {
  private int level;
  private String title;
  private int reputation;
  private String[] team;
  private String savedLocation;
  private String lastLocation;
  
  public int getLevel() {
    return level;
  }
  public void setLevel(int level) {
    this.level = level;
  }
  public String getTitle() {
    return title;
  }
  public void setTitle(String title) {
    this.title = title;
  }
  public int getReputation() {
    return reputation;
  }
  public void setReputation(int reputation) {
    this.reputation = reputation;
  }
  public String[] getTeam() {
    return team;
  }
  public void setTeam(String[] team) {
    this.team = team;
  }
  public String getSavedLocation() {
    return savedLocation;
  }
  public void setSavedLocation(String savedLocation) {
    this.savedLocation = savedLocation;
  }
  public String getLastLocation() {
    return lastLocation;
  }
  public void setLastLocation(String lastLocation) {
    this.lastLocation = lastLocation;
  }
}
