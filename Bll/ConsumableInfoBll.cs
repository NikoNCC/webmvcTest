using Dal;
using Entity;
using Entiy;
using Entiy.Dtos;
using IBLL;
using IDal;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bll
{
    /// <summary>
    /// 耗材管理Bll
    /// </summary>
    public class ConsumableInfoBll: IConsumableInfoBll
    {
        IConsumableInfoDal _IConsumableInfoDal;
        ICategoryDal _ICategoryDal;
        StorehouseSysDbContext _dbContext;
        IConsumableRecordDal _ConsumableRecordDal;
        IUserInfoDal _IuserInfoDal;
        public ConsumableInfoBll(IConsumableInfoDal iConsumableInfoDal, IUserInfoDal userInfoDal , ICategoryDal icategoryDal, StorehouseSysDbContext dbContext, IConsumableRecordDal consumableRecordDal)
        {
            _IConsumableInfoDal = iConsumableInfoDal;
            _ICategoryDal = icategoryDal;
            _dbContext = dbContext;
            _ConsumableRecordDal = consumableRecordDal;
            _IuserInfoDal = userInfoDal;
        }

        /// <summary>
        /// 添加耗材
        /// </summary>
        /// <param name="consumableInfoDtos"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool AddConsumableInfo(ConsumableInfoDtos consumableInfoDtos,out string msg)
        {
            ConsumableInfo consumableInfo = new ConsumableInfo() { 
                Id = Guid.NewGuid().ToString(),
                CategoryId = consumableInfoDtos.CategoryId,
                ConsumableName =consumableInfoDtos.ConsumableName,
                CreateTime = DateTime.Now,
                Description = consumableInfoDtos.Description,
                Money =consumableInfoDtos.Money,
                Num =consumableInfoDtos.Num,
                Specification= consumableInfoDtos.Specification,
                Unit = consumableInfoDtos.Unit,
                WarningNum = consumableInfoDtos.WarningNum
            };
            bool res =_IConsumableInfoDal.AddEntity(consumableInfo);
            if (res)
            {
                msg = "添加成功";
                return res;
            }
            msg = "添加失败";
            return res;
        }

        /// <summary>
        /// /删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteConsumableInfo(string[] ids, out string msg)
        {
            List<ConsumableInfo> list = new List<ConsumableInfo>();
            foreach (var i in ids)
            {
                ConsumableInfo consumableInfo = _IConsumableInfoDal.FindEntity(i);
                if (consumableInfo == null)
                {
                    msg = "选中的耗材有误";
                    return false;
                }
                list.Add(consumableInfo);
            }
          
          bool res =  _IConsumableInfoDal.DelEntity(list);
            msg = "删除失败";
            if (res)
            {
                msg = "删除成功";
            }
            return res;
        }

        /// <summary>
        /// 获取耗材下拉框
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoryOptions()
        {
            List<Category> list = _ICategoryDal.GetEntity().ToList();
            return list;
        }

        /// <summary>
        /// 获取耗材信息
        /// </summary>
        /// <returns></returns>
        public List<ConsumableInfo> GetConsumableInfos( )
        {
            List<ConsumableInfo> list = _IConsumableInfoDal.GetEntity().Where(a => !a.IsDelete).ToList();
            return list;
        }

        /// <summary>
        /// 获取选中耗材数据用于修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ConsumableInfo GetUpdateConsumableInfo(string id,out string msg)
        {   if (string.IsNullOrEmpty(id))
            {
                msg = "选中的耗材不能为空";
                return null;
            }
            ConsumableInfo consumableInfo = _IConsumableInfoDal.FindEntity(id);
            if (consumableInfo == null)
            {
                msg = "选中的耗材不存在";
                return null;

            }
            msg = "选中的数据";
            return consumableInfo;
        }

        /// <summary>
        /// 修改耗材信息
        /// </summary>
        /// <param name="consumableInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateConsumableInfo(ConsumableInfo consumableInfo, out string msg)
        {
            if (consumableInfo.Id == null)
            {
                msg = "选中的耗材不能为空";
                return false;
            }
            ConsumableInfo list = _IConsumableInfoDal.FindEntity(consumableInfo.Id);
            if(list ==null)
            {
                msg = "选中的耗材不存在";
                return false;
            
             }
            list.Unit=consumableInfo.Unit;
            list.Specification = consumableInfo.Specification;
            list.CategoryId = consumableInfo.CategoryId;
            list.Money =consumableInfo.Money;
            list.WarningNum = consumableInfo.WarningNum;
            list.CreateTime = consumableInfo.CreateTime;
            list.Description = consumableInfo.Description;
           
            bool res =_IConsumableInfoDal.UpdateEntiry(list);
            if (res) {
                msg = "修改成功";
                return res;
            }
            msg = "修改失败";
            return res;
        }
        /// <summary>
        /// 耗材入库
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="userId"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UploadConsumableInfo(IFormFile formFile, string userId, out string msg)
        {
            IWorkbook wk = null;
            // 获取文件的后缀名
            string extension = Path.GetExtension(formFile.FileName);
            if (extension == ".xls" || extension == ".xlsx")
            {
                using (Stream stream = formFile.OpenReadStream())
                {
                    // 判断文件后缀名
                    if (extension.Equals(".xls"))
                    {
                        wk = new HSSFWorkbook(stream);
                    }
                    else
                    {
                        wk = new XSSFWorkbook(stream);
                    }
                }
                // 获取第一张表数据
                ISheet sheet = wk.GetSheetAt(0);
                // 获取到表第一行数据
                IRow row = sheet.GetRow(0);
                // 校验文件数据是否正确
                if (row.GetCell(0).ToString() != "物品名称" || row.GetCell(1).ToString() != "数量" || row.GetCell(2).ToString() != "实际购买数量" || row.GetCell(3).ToString() != "规格")
                {
                    msg = "文件数据格式错误!";
                    return false;
                }
                using (var dbTransaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 1; i <= sheet.LastRowNum; i++)
                        {
                            // 获取对应行的前三个格子文本
                            string cell_1 = sheet.GetRow(i).GetCell(0).ToString(); // 名称
                            string cell_3 = sheet.GetRow(i).GetCell(2).ToString(); // 实际购买数量
                            string cell_4 = sheet.GetRow(i).GetCell(3).ToString(); // 规格

                            int num = 0;
                            int.TryParse(cell_3, out num);
                            // 获取对应耗材Id
                            var consumable = _IConsumableInfoDal.GetEntity().FirstOrDefault(c => c.ConsumableName.Equals(cell_1));
                            if (consumable != null)
                            {
                                // 创建耗材记录对象并赋值
                                ConsumableRecord consumableRecord = new ConsumableRecord()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    ConsumableId = consumable.Id,
                                    CreateTime = DateTime.Now,
                                    Num = Convert.ToInt32(cell_3),
                                    Creator = userId,
                                };
                                // 执行添加操作
                                if (!_ConsumableRecordDal.AddEntity(consumableRecord))
                                {
                                    msg = $"导入{i}行数据发生错误";
                                    // 回滚
                                    dbTransaction.Rollback();
                                    return false;
                                }

                                // 修改耗材信息数量业务
                                // 通过耗材信息Id获取到耗材信息
                                ConsumableInfo consumableInfo = _IConsumableInfoDal.GetEntity().FindAsync(consumable.Id).Result;
                                // 修改耗材数量
                                consumableInfo.Num = consumableInfo.Num + Convert.ToInt32(cell_3);
                                if (!_IConsumableInfoDal.UpdateEntiry(consumableInfo))
                                {
                                    msg = $"修改{i}行耗材数据发生错误";
                                    // 回滚
                                    dbTransaction.Rollback();
                                    return false;
                                }


                            }
                            else
                            {
                                msg = $"第{i}行耗材信息发生错误，导入失败";
                                // 回滚
                                dbTransaction.Rollback();
                                return false;
                            }
                        }
                        // 提交事务
                        dbTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        msg = "导入数据发生未知错误";
                        // 回滚
                        dbTransaction.Rollback();
                        return false;
                    }
                }

                msg = "导入数据成功";
                return false;
            }
            else
            {
                msg = "文件类型错误";
                return false;
            }

        }
        /// <summary>
        /// 耗材出库业务
        /// </summary>
        public FileStream OutOfStockBll()
        {
            // 获取要导出的数据
            var data = (from a in _ConsumableRecordDal.GetEntity()
                        join b in _IConsumableInfoDal.GetEntity()
                        on a.ConsumableId equals b.Id
                        into abJoin
                        from bData in abJoin.DefaultIfEmpty()

                        join c in _IuserInfoDal.GetEntity()
                        on a.Creator equals c.Id
                        into acJoin
                        from cData in acJoin.DefaultIfEmpty()
                        select new
                        {
                            cData.UserName,
                            bData.ConsumableName,
                            a.Num,
                            bData.Money,
                            bData.Specification
                        }).ToList();

            // 获取文件路径
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.xlsx");
            IWorkbook workbook = null;
            if (Path.GetExtension(filePath).Equals(".xlsx"))
            {
                workbook = new XSSFWorkbook();
            }
            else
            {
                workbook = new HSSFWorkbook();
            }
            ISheet sheet = workbook.CreateSheet("sheet1");
            // 创建第一行并初始化表头
            IRow row0 = sheet.CreateRow(0);
            row0.CreateCell(0).SetCellValue("创建人");
            row0.CreateCell(1).SetCellValue("名称");
            row0.CreateCell(2).SetCellValue("数量");
            row0.CreateCell(3).SetCellValue("单价");
            row0.CreateCell(4).SetCellValue("规格");
            for (int i = 0; i < data.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                // 创建人
                row.CreateCell(0).SetCellValue(data[i].UserName);
                // 耗材名称
                row.CreateCell(1).SetCellValue(data[i].ConsumableName);
                // 耗材数量
                row.CreateCell(2).SetCellValue(data[i].Num);
                // 耗材单价
                row.CreateCell(3).SetCellValue((double)data[i].Money);
                // 耗材规格
                row.CreateCell(4).SetCellValue(data[i].Specification);
            }
            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            workbook.Write(fileStream);

            // 获取指定文件的文件流
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            return fs;
        }
    }
}
