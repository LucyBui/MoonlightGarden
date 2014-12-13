package com.moonlightgarden.repository;

import java.util.Map;

import com.moonlightgarden.entity.MasterData;
import com.moonlightgarden.enumeration.MasterDataType;
import com.moonlightgarden.platform.CachedRepository;
import com.moonlightgarden.platform.OutputData;

public class MasterDataRepository extends CachedRepository<MasterData> {
  public Map<String, Class<? extends OutputData>> filterByType(Class<? extends OutputData> resultClass, MasterDataType type) {
    return super.filterByRowKey(resultClass, type.toString());
  }
}
