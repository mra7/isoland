# 项目结构
为了防止单例满天飞的情况，使用App来对类的注册，生命周期等进行管理。同时通过注入尽量减少拖拽绑定。门面模式屏蔽掉Managers初始化的复杂度。
## 命名空间层次关系
高层才可以访问低层，低层互相不知道存在。传递消息使用事件码。  
App 最高层，程序入口。  
Controller 业务逻辑。  
Facades  管理缓存，存放一切All开头文件，使用静态类。  （弃用）  
Managers 管理器， 负责生成注入等，主要负责各种东西的拖拽绑定。（已弃用，所有逻辑都归controller管理， 音频由于绑定了资源暂时先取名为manager）  
Models 负责怪物，角色等Item自己的逻辑。  

## 文件夹说明
LibDst(library destination) => 用于存放各类prefab预制件，通过AA包管理预制件。(已弃用AA包)  
UI => 用于存放各类UI的脚本。  
Assets => 存放各种静态资源。（弃用）  
Facades => 用于存储各种Allxxx。（弃用）  
## App
  代码主入口，只在这里执行Update、Start等，此时各Manager等的Update执行顺序严格遵照App.Update()内写入的顺序进行执行。

## TODO 
研究如何减少拖拽绑定 AA包  
如果通过gameassets 注入资源 会生成public类给controller使用， 会让其他类也可以使用。（？）  
通过事件已经解决了单例的问题（？）
