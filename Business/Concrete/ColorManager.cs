using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            this._colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Color>> GetAll()
        {

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(x => x.IsDelete == false), Messages.Listed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            throw new NotImplementedException();
        }
        public IResult Delete(Color color)
        {
            _colorDal.UpdateDelete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }

        public IResult UpdateDelete(Color color)
        {
            _colorDal.UpdateDelete(color);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
