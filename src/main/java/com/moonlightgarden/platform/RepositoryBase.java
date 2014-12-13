package com.moonlightgarden.platform;

import java.util.Map;

public abstract class RepositoryBase<T extends InputData> {
  public Map<String, Class<? extends OutputData>> filterByRowKey(Class<? extends OutputData> resultClass, String rowKey) {
    return null;
  }
}
