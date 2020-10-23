### docker安装MySQL

1. 拉取MySQL镜像

   `docker pull mysql:5.7`MySQL5.7版本

   `docker pull mysql:latest`最新版本

   

2. 创建容器

   `docker run --name mysql-master -p 3307:3306 -v /0982/master:/etc/mysql/myssql.conf.d -e MYSQL_ROOT_PASSWORD=123456 -d mysql:5.7 `

   以MySQL5.7镜像创建MySQL容器并挂载配置文件目录到/etc/mysql/myssql.cong.d

3. 配置文件更改



