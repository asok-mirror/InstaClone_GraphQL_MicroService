from datetime import datetime

class Comment:
    def __init__(self, id, userId, postId, description, createdOn = datetime.now()):
        self.id = id
        self.userId = userId
        self.postId = postId
        self.description = description
        self.createdOn = createdOn