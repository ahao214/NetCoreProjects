﻿using SqlSugar;
using System.Reflection;

namespace JOKER.NetE.Repository.UnitOfWorks
{
    public interface IUnitOfWorkManage
    {
        SqlSugarScope GetDbClient();
        int TranCount { get; }

        UnitOfWork CreateUnitOfWork();

        void BeginTran();
        void BeginTran(MethodInfo method);
        void CommitTran();
        void CommitTran(MethodInfo method);
        void RollbackTran();
        void RollbackTran(MethodInfo method);

    }
}
