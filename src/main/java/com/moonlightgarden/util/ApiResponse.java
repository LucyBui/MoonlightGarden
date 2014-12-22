package com.moonlightgarden.util;

public class ApiResponse {
  private boolean success;
  private Object data;
  
  public ApiResponse(Object data) {
    this.success = data != null;
    this.data = data;
  }

  public boolean isSuccess() {
    return success;
  }
  public void setSuccess(boolean success) {
    this.success = success;
  }
  public Object getData() {
    return data;
  }
  public void setData(Object data) {
    this.data = data;
  }
}
