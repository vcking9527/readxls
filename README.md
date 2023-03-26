手把手建置ELK

安裝 VSCODE
	1. 從官網下載並安裝
	2. 使用指令安裝
	01.以 sudo 用户身份运行下面的命令，更新软件包索引，并且安装依赖软件：
	sudo apt update
sudo apt install software-properties-common apt-transport-https wget
	02.使用 wget 命令插入 Microsoft GPG key ：
	wget -q https://packages.microsoft.com/keys/microsoft.asc -O- | sudo apt-key add -
	启用 Visual Studio Code 源仓库，输入：
	sudo add-apt-repository "deb [arch=amd64] https://packages.microsoft.com/repos/vscode stable main"
	03.一旦 apt 软件源被启用，安装 Visual Studio Code 软件包：
	sudo apt install code
	当一个新版本被发布时，你可以通过你的桌面标准软件工具，或者在你的终端运行命令，来升级 Visual Studio Code 软件包：
	sudo apt update
sudo apt upgrade
	
	來自 <https://zhuanlan.zhihu.com/p/137861452> 
	
安裝git
	1. 從 apt指令安裝
	sudo apt update
sudo apt install git
	git --version
	2. 從源碼安裝
	sudo apt update
sudo apt install dh-autoreconf libcurl4-gnutls-dev libexpat1-dev make gettext libz-dev libssl-dev libghc-zlib-dev
	
	下一步，打开你的浏览器，浏览 Github 上的 Git 项目镜像 并且 拷贝最新的 以.tar.gz结尾的发行版链接 URL
	> 
	
	我们将会下载，并且解压 Git 源码到 /usr/src目录。这个目录通常被用来放置源代码。
	
	wget -c https://github.com/git/git/archive/v2.26.2.tar.gz -O - | sudo tar -xz -C /usr/src
	当下载完成时，切换源码目录，并且运行下面的命令来编译和安装 Git：
	
	cd /usr/src/git-*
	sudo make prefix=/usr/local all
	sudo make prefix=/usr/local install
	编译过程会花费几分钟。一旦完成，验证安装过程，运行：
	
	git --version
	
安裝nodejs
	安裝LTS版本
	
	sudo apt-get install curl
	curl -sL https://deb.nodesource.com/setup_16.x | sudo -E bash -
	 sudo apt-get install nodejs
	node -v
	npm -v
	
	來自 <https://blog.impochun.com/how-to-install-latest-nodejs-on-ubuntu/> 
	
	
安裝vue-cli
	npm install -g @vue/cli
	vue -V  << 大寫
	
	來自 <https://ithelp.ithome.com.tw/articles/10237012> 
安裝dotnet core
1. 下載與安裝.Net Core SDK 
可參考官方文件: https://docs.microsoft.com/zh-tw/dotnet/core/install/linux-ubuntu#apt-troubleshooting
1.1. 下載 .Net core 安裝檔
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
1.2. 安裝 .Net core SDK
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-6.0

來自 <https://dotblogs.com.tw/CodeBrewTea/2021/11/18/173313> 




11
安裝docker
	https://linnote.com/how-to-install-docker-in-ubuntu/
	避免與原先的版本衝突，建議把原本舊安裝過的docker移除掉
	sudo apt-getremove docker docker-engine docker.io containerd runc
	如果想要進階一點手動去檢查是否完全刪除原本舊有的docker可以直接:
	sudo rm-rf /var/lib/docker
sudo rm-rf /var/lib/containerd
	
	來自 <https://linnote.com/how-to-install-docker-in-ubuntu/> 
	
	使用apt-get安裝
	設定repository
	1. 更新apt安裝包以及apt所需的相關套件
	sudo apt-get update
	sudoapt-getinstall\
    ca-certificates \
    curl\
    gnupg \
    lsb-releasz
	2. 加入docker的官方GPG Key:
	sudo mkdir -p /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/ubuntu/gpg |sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
	3. Set up the repository:
	echo\
  "deb [arch=$(dpkg --print-architecture)signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs)stable"|sudo tee/etc/apt/sources.list.d/docker.list >/dev/null
	
	來自 <https://linnote.com/how-to-install-docker-in-ubuntu/> 
	
	安裝Docker Engine
	4. apt更新以確保可以安裝最新的docker，並進行安裝:
	sudoapt-getupdate
sudoapt-getinstalldocker-ce docker-ce-cli containerd.io docker-compose-plugin
	5. 確認是否安裝成功
	sudodocker run hello-world
	
	來自 <https://linnote.com/how-to-install-docker-in-ubuntu/> 
	


git config 使用者設定
$ git config --global user.name "Eddie Kao"
$ git config --global user.email "eddie@5xruby.tw"


$ git config --list
user.name=Eddie Kao
user.email=eddie@5xruby.tw


解决remote: Support for password authentication was removed on August 13, 2021. Please use a perso

來自 <https://blog.51cto.com/greyfoss/5707648> 


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

https://github.com/changemyminds/ELK-Demo.git
	
git remote set-url origin  https://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@github.com/changemyminds/ELK-Demo.git

git  clone https://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@github.com/changemyminds/ELK-Demo.git

fatal: No such remote 'origin'
git remote add origin ssh://user@115.115.115.115/develop/git/test.git

解决 ERROR: Couldn't connect to Docker daemon at http+docker://localunixsocket - is it running?


https://www.cnblogs.com/shuhe-nd/p/13037876.html


基本Kibana操作KQL

來自 <https://github.com/changemyminds/ELK-Demo/blob/master/README.md> 

Dev Tools
GET _cat/indices?v
