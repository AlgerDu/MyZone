/** 查询添加操作类型 */
export enum SearchConditionFilterOperationType {
    equal = 1,
    less,
    more,
    like,
    order
}

/** 列表查询条件过滤项 */
export class SearchConditionFilter {
    field: string;
    value: string;
    op: SearchConditionFilterOperationType;
}

/** 查询条件 */
export class SearchConfition {
    pageSize: number;
    pageIndex: number;
    filterItems: Array<SearchConditionFilter>;
}