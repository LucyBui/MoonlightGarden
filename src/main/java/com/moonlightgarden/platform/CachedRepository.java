package com.moonlightgarden.platform;

import java.util.Map;

public class CachedRepository<T extends InputData> extends RepositoryBase<T> {
  public Map<String, Class<? extends OutputData>> filterByRowKey(Class<? extends OutputData> resultClass, String rowKey) {
    Map<String, Class<? extends OutputData>> map = super.filterByRowKey(resultClass, rowKey);
    return map;
  }
}
