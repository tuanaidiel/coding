from sqlalchemy import Column
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.types import Integer, String, Double

Base = declarative_base()

class Products(Base):

    __tablename__ = "products" 

    id = Column (Integer, primary_key= True, autoincrement= True)
    name = Column (String (60), nullable= False )
    quantity = Column (Integer, nullable= False )
    price = Column (Double, nullable= False) 



    





