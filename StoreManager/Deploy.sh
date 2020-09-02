#!/bin/bash
exec "sudo docker build --tag registry.heroku.com/my-store-manager/web ."
exec "sudo heroku container : push -a my-store-manager"
exec "sudo heroku container: release -a my-store-manager"
